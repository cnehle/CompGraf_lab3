using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private Bitmap canvas;
        private RadioButton bresenhamRadio;
        private RadioButton wuRadio;
        private Button clearButton;
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing;

        private readonly Color bresenhamColor = Color.Green;
        private readonly Color wuColor = Color.Red;

        // Смещение области рисования
        private const int CanvasOffsetY = 80;

        public Form1()
        {
            InitializeComponent();
            InitializeCanvas();
            InitializeControls();
        }

        private void InitializeCanvas()
        {
            canvas = new Bitmap(800, 600);
            ClearCanvas();
        }

        private void InitializeControls()
        {
            this.Text = "Алгоритмы рисования отрезков";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            bresenhamRadio = new RadioButton()
            {
                Text = "Брезенхем (Зелёный)",
                Location = new Point(20, 20),
                Size = new Size(150, 20),
                Checked = true
            };

            wuRadio = new RadioButton()
            {
                Text = "Ву (Красный)",
                Location = new Point(20, 45),
                Size = new Size(120, 20)
            };

            clearButton = new Button()
            {
                Text = "Очистить",
                Location = new Point(180, 30),
                Size = new Size(80, 30)
            };
            clearButton.Click += ClearButton_Click;

            this.Controls.AddRange(new Control[] { bresenhamRadio, wuRadio, clearButton });

            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Paint += Form1_Paint;
        }

        private void ClearCanvas()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }
            this.Invalidate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearCanvas();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Корректируем координаты с учётом смещения холста
                startPoint = new Point(e.X, e.Y - CanvasOffsetY);
                isDrawing = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Корректируем координаты с учётом смещения холста
                endPoint = new Point(e.X, e.Y - CanvasOffsetY);
                DrawPreviewLine();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDrawing)
            {
                // Корректируем координаты с учётом смещения холста
                endPoint = new Point(e.X, e.Y - CanvasOffsetY);
                DrawFinalLine();
                isDrawing = false;
            }
        }

        private void DrawPreviewLine()
        {
            Bitmap tempCanvas = new Bitmap(canvas);

            Color previewColor = bresenhamRadio.Checked ? bresenhamColor : wuColor;

            if (bresenhamRadio.Checked)
            {
                DrawLineBresenham(tempCanvas, startPoint, endPoint, previewColor);
            }
            else
            {
                DrawLineWu(tempCanvas, startPoint, endPoint, previewColor);
            }

            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                g.DrawImage(tempCanvas, 0, CanvasOffsetY);
            }
        }

        private void DrawFinalLine()
        {
            Color finalColor = bresenhamRadio.Checked ? bresenhamColor : wuColor;

            if (bresenhamRadio.Checked)
            {
                DrawLineBresenham(canvas, startPoint, endPoint, finalColor);
            }
            else
            {
                DrawLineWu(canvas, startPoint, endPoint, finalColor);
            }
            this.Invalidate();
        }

        private void DrawLineBresenham(Bitmap bmp, Point start, Point end, Color color)
        {
            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;

            // Проверяем, чтобы координаты были в пределах холста
            if (x0 < 0 || x0 >= bmp.Width || y0 < 0 || y0 >= bmp.Height ||
                x1 < 0 || x1 >= bmp.Width || y1 < 0 || y1 >= bmp.Height)
                return;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            if (dy <= dx)
            {
                if (x0 > x1)
                {
                    Swap(ref x0, ref x1);
                    Swap(ref y0, ref y1);
                }

                int yi = y0 < y1 ? 1 : -1;
                int D = 2 * dy - dx;
                int y = y0;

                for (int x = x0; x <= x1; x++)
                {
                    SetPixel(bmp, x, y, color);
                    if (D > 0)
                    {
                        y += yi;
                        D += 2 * (dy - dx);
                    }
                    else
                    {
                        D += 2 * dy;
                    }
                }
            }
            else
            {
                if (y0 > y1)
                {
                    Swap(ref x0, ref x1);
                    Swap(ref y0, ref y1);
                }

                int xi = x0 < x1 ? 1 : -1;
                int D = 2 * dx - dy;
                int x = x0;

                for (int y = y0; y <= y1; y++)
                {
                    SetPixel(bmp, x, y, color);
                    if (D > 0)
                    {
                        x += xi;
                        D += 2 * (dx - dy);
                    }
                    else
                    {
                        D += 2 * dx;
                    }
                }
            }
        }

        private void DrawLineWu(Bitmap bmp, Point p1, Point p2, Color color)
        {
            int x0 = p1.X;
            int y0 = p1.Y;
            int x1 = p2.X;
            int y1 = p2.Y;

            // Проверяем, чтобы координаты были в пределах холста
            if (x0 < 0 || x0 >= bmp.Width || y0 < 0 || y0 >= bmp.Height ||
                x1 < 0 || x1 >= bmp.Width || y1 < 0 || y1 >= bmp.Height)
                return;

            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = (dx == 0) ? 1 : dy / dx;

            float xend = Round(x0);
            float yend = y0 + gradient * (xend - x0);
            float xgap = 1 - FractionalPart(x0 + 0.5f);
            int xpxl1 = (int)xend;
            int ypxl1 = (int)yend;

            if (steep)
            {
                SetPixelAlpha(bmp, ypxl1, xpxl1, color, (1 - FractionalPart(yend)) * xgap);
                SetPixelAlpha(bmp, ypxl1 + 1, xpxl1, color, FractionalPart(yend) * xgap);
            }
            else
            {
                SetPixelAlpha(bmp, xpxl1, ypxl1, color, (1 - FractionalPart(yend)) * xgap);
                SetPixelAlpha(bmp, xpxl1, ypxl1 + 1, color, FractionalPart(yend) * xgap);
            }

            float intery = yend + gradient;

            xend = Round(x1);
            yend = y1 + gradient * (xend - x1);
            xgap = FractionalPart(x1 + 0.5f);
            int xpxl2 = (int)xend;
            int ypxl2 = (int)yend;

            if (steep)
            {
                SetPixelAlpha(bmp, ypxl2, xpxl2, color, (1 - FractionalPart(yend)) * xgap);
                SetPixelAlpha(bmp, ypxl2 + 1, xpxl2, color, FractionalPart(yend) * xgap);
            }
            else
            {
                SetPixelAlpha(bmp, xpxl2, ypxl2, color, (1 - FractionalPart(yend)) * xgap);
                SetPixelAlpha(bmp, xpxl2, ypxl2 + 1, color, FractionalPart(yend) * xgap);
            }

            if (steep)
            {
                for (int x = xpxl1 + 1; x < xpxl2; x++)
                {
                    SetPixelAlpha(bmp, (int)intery, x, color, 1 - FractionalPart(intery));
                    SetPixelAlpha(bmp, (int)intery + 1, x, color, FractionalPart(intery));
                    intery += gradient;
                }
            }
            else
            {
                for (int x = xpxl1 + 1; x < xpxl2; x++)
                {
                    SetPixelAlpha(bmp, x, (int)intery, color, 1 - FractionalPart(intery));
                    SetPixelAlpha(bmp, x, (int)intery + 1, color, FractionalPart(intery));
                    intery += gradient;
                }
            }
        }

        private void SetPixel(Bitmap bmp, int x, int y, Color color)
        {
            if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
            {
                bmp.SetPixel(x, y, color);
            }
        }

        private void SetPixelAlpha(Bitmap bmp, int x, int y, Color color, float alpha)
        {
            if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
            {
                Color background = bmp.GetPixel(x, y);
                Color result = BlendColors(background, color, alpha);
                bmp.SetPixel(x, y, result);
            }
        }

        private Color BlendColors(Color background, Color foreground, float alpha)
        {
            float r = background.R * (1 - alpha) + foreground.R * alpha;
            float g = background.G * (1 - alpha) + foreground.G * alpha;
            float b = background.B * (1 - alpha) + foreground.B * alpha;

            return Color.FromArgb(
                (int)Math.Min(255, r),
                (int)Math.Min(255, g),
                (int)Math.Min(255, b)
            );
        }

        private float FractionalPart(float x)
        {
            return x - (int)x;
        }

        private int Round(float x)
        {
            return (int)(x + 0.5f);
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(canvas, 0, CanvasOffsetY);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            canvas?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
