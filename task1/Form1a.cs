using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace lab2_task1
{
    public partial class Form1a : Form
    {
        private Bitmap bitmap;
        private Color borderColor = Color.Black;
        private Point startPoint;
        private Point previousPoint;
        private bool isDrawing = false;
        private Random random = new Random();
        private List<Color> usedColors = new List<Color>();
        private Color currentFillColor;

        public Form1a()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            ClearBitmap();
            pictureBox1.Image = bitmap;
            GenerateNewColor();
        }

        private void ClearBitmap()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
            }
            usedColors.Clear();
            GenerateNewColor();
            pictureBox1.Refresh();
        }

        private void GenerateNewColor()
        {
            // Генерируем новый цвет, который еще не использовался
            Color newColor;
            do
            {
                newColor = Color.FromArgb(
                    random.Next(50, 256),  // R 
                    random.Next(50, 256),  // G
                    random.Next(50, 256)   // B
                );
            }
            while (usedColors.Contains(newColor));

            currentFillColor = newColor;
            usedColors.Add(newColor);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Начинаем рисовать линию
                isDrawing = true;
                previousPoint = e.Location;

                // Ставим первую точку
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.FillEllipse(new SolidBrush(borderColor), e.X - 2, e.Y - 2, 4, 4);
                }
                pictureBox1.Refresh();
            }
            else if (e.Button == MouseButtons.Right)
            {
                isDrawing = false;
                startPoint = e.Location;

                GenerateNewColor();
                FloodFill(startPoint.X, startPoint.Y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                // Рисуем линию от предыдущей точки к текущей
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Pen pen = new Pen(borderColor, 3);
                    g.DrawLine(pen, previousPoint, e.Location);
                    pen.Dispose();
                }
                previousPoint = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void FloodFill(int x, int y)
        {
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return;

            Color targetColor = bitmap.GetPixel(x, y);
            if (targetColor.ToArgb() == currentFillColor.ToArgb() || targetColor.ToArgb() == borderColor.ToArgb())
                return;

            // Находим левую границу серии пикселов
            int left = x;
            while (left > 0 && bitmap.GetPixel(left - 1, y).ToArgb() == targetColor.ToArgb())
            {
                left--;
            }

            // Находим правую границу серии пикселов
            int right = x;
            while (right < bitmap.Width - 1 && bitmap.GetPixel(right + 1, y).ToArgb() == targetColor.ToArgb())
            {
                right++;
            }

            // Заливаем серию пикселов
            for (int i = left; i <= right; i++)
            {
                bitmap.SetPixel(i, y, currentFillColor);
            }

            pictureBox1.Refresh();
            Application.DoEvents();

            // Рекурсивно заливаем соседние строки
            for (int i = left; i <= right; i++)
            {
                if (y > 0 && bitmap.GetPixel(i, y - 1).ToArgb() == targetColor.ToArgb())
                {
                    FloodFill(i, y - 1);
                }
                if (y < bitmap.Height - 1 && bitmap.GetPixel(i, y + 1).ToArgb() == targetColor.ToArgb())
                {
                    FloodFill(i, y + 1);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearBitmap();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
