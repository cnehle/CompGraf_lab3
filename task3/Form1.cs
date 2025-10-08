using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            DrawTriangle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawTriangle();
        }

        private void DrawTriangle()
        {
            int w = pictureBox1.Width;                     
            int h = pictureBox1.Height;                   
            if (w <= 0 || h <= 0) return;

            Bitmap bmp = new Bitmap(w, h);                 

            PointF v0 = new PointF(20, 20);                
            Color c0 = Color.Red;                           

            PointF v1 = new PointF(w - 30, 60);            
            Color c1 = Color.Lime;                          

            PointF v2 = new PointF(w / 2f, h - 30);         
            Color c2 = Color.Blue;                         

            RasterizeTriangle(bmp, v0, c0, v1, c1, v2, c2);
                                                            
            var old = pictureBox1.Image;                    
            pictureBox1.Image = bmp;                        
            old?.Dispose();                                 
        }

        private static double Edge(double ax, double ay, double bx, double by, double cx, double cy)
        {
            return (bx - ax) * (cy - ay) - (by - ay) * (cx - ax); //пол.значение—точка по одну сторону от ориен.грани, отриц.—по другую.
        }

        private static Color InterpolateColor(Color c0, Color c1, Color c2, double w0, double w1, double w2)
        {
            int r = (int)Math.Round(w0 * c0.R + w1 * c1.R + w2 * c2.R); //для каждого канала взвешенное среднее значение в вершинах
            int g = (int)Math.Round(w0 * c0.G + w1 * c1.G + w2 * c2.G); 
            int b = (int)Math.Round(w0 * c0.B + w1 * c1.B + w2 * c2.B); 
            int a = (int)Math.Round(w0 * c0.A + w1 * c1.A + w2 * c2.A); 

            r = Math.Min(255, Math.Max(0, r));             
            g = Math.Min(255, Math.Max(0, g));             
            b = Math.Min(255, Math.Max(0, b));               
            a = Math.Min(255, Math.Max(0, a));               

            return Color.FromArgb(a, r, g, b);               // создаём и возвращаем итоговый цвет
        }

        private static void RasterizeTriangle(Bitmap bmp,
                                              PointF v0, Color c0,
                                              PointF v1, Color c1,
                                              PointF v2, Color c2)
        {
            int width = bmp.Width;                          
            int height = bmp.Height;                  

            int minX = (int)Math.Floor(Math.Min(v0.X, Math.Min(v1.X, v2.X))); // минимальная X среди вершин, округл. вниз
            int maxX = (int)Math.Ceiling(Math.Max(v0.X, Math.Max(v1.X, v2.X))); //пришлось бы тест. каждый пиксель буфера на вхождение в треуг.
            int minY = (int)Math.Floor(Math.Min(v0.Y, Math.Min(v1.Y, v2.Y)));
            int maxY = (int)Math.Ceiling(Math.Max(v0.Y, Math.Max(v1.Y, v2.Y))); 

            minX = Math.Max(minX, 0);                         // клиппируем левую границу к 0 (не выходим за изображение)
            minY = Math.Max(minY, 0);                         
            maxX = Math.Min(maxX, width - 1);             
            maxY = Math.Min(maxY, height - 1);                

            double area = Edge(v0.X, v0.Y, v1.X, v1.Y, v2.X, v2.Y); 
            if (Math.Abs(area) < 1e-9) return;                // если площадь почти 0 — треугольник вырожден, выходим

            for (int y = minY; y <= maxY; y++)               
            {
                for (int x = minX; x <= maxX; x++)            
                {
                    double px = x + 0.5;                   
                    double py = y + 0.5;                      

                    // вычисляем барицентрические координаты (веса) через edge-функции, нормированные на area
                    double w0 = Edge(v1.X, v1.Y, v2.X, v2.Y, px, py) / area; // вес для вершины v0
                    double w1 = Edge(v2.X, v2.Y, v0.X, v0.Y, px, py) / area; // v1
                    double w2 = Edge(v0.X, v0.Y, v1.X, v1.Y, px, py) / area; // v2

                    // точка внутри, если все barycentric имеют одинаковый знак
                    if ((w0 >= 0 && w1 >= 0 && w2 >= 0) || (w0 <= 0 && w1 <= 0 && w2 <= 0))
                    {
                        // смысл проверки: точка внутри (или на границе), если все веса >=0 (для одного ориентирования)
                        // либо все <=0 (если ориентация треугольника обратная). Такой подход независим от winding.

                        Color col = InterpolateColor(c0, c1, c2, w0, w1, w2); // интерполируем цвет по весам
                        bmp.SetPixel(x, y, col);                                                                     
                    }
                }
            }
        }
    }
}