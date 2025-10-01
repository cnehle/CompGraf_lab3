using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace lab2_task1
{
    public partial class Form1c : Form
    {
        private Bitmap originalBitmap;
        private Bitmap displayBitmap;
        private Color borderColor = Color.Red;
        private Color highlightColor = Color.Yellow;
        private List<Point> borderPoints = new List<Point>();
        private bool isImageLoaded = false;

        public Form1c()
        {
            InitializeComponent();
            CreateBlankImage();
        }

        private void CreateBlankImage()
        {
            // Создаем пустое изображение
            originalBitmap = new Bitmap(600, 500);
            using (Graphics g = Graphics.FromImage(originalBitmap))
            {
                g.Clear(Color.White);
            }
            displayBitmap = new Bitmap(originalBitmap);
            pictureBoxDisplay.Image = displayBitmap;
            isImageLoaded = true;
            labelImageInfo.Text = "Размер: 600x500";
        }

        private void pictureBoxDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isImageLoaded || originalBitmap == null)
            {
                MessageBox.Show("Сначала создайте изображение!",
                              "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                // Начинаем обход границы с выбранной точки
                Point startPoint = e.Location;

                // Проверяем, что точка находится на границе
                Color pixelColor = originalBitmap.GetPixel(startPoint.X, startPoint.Y);
                if (pixelColor.ToArgb() != borderColor.ToArgb())
                {
                    MessageBox.Show("Выберите точку на границе (красного цвета)!",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FindBorder(startPoint.X, startPoint.Y);
            }
        }

        private void FindBorder(int startX, int startY)
        {
            borderPoints.Clear();
            listBoxBorderPoints.Items.Clear();

            // Восстанавливаем оригинальное изображение
            displayBitmap = new Bitmap(originalBitmap);
            pictureBoxDisplay.Image = displayBitmap;
            pictureBoxDisplay.Refresh();

            // Направления для обхода (по часовой стрелке)
            Point[] directions = {
                new Point(1, 0),   // вправо
                new Point(1, 1),   // вправо-вниз
                new Point(0, 1),   // вниз
                new Point(-1, 1),  // влево-вниз
                new Point(-1, 0),  // влево
                new Point(-1, -1), // влево-вверх
                new Point(0, -1),  // вверх
                new Point(1, -1)   // вправо-вверх
            };

            HashSet<Point> visited = new HashSet<Point>();
            Stack<Point> stack = new Stack<Point>();

            Point startPoint = new Point(startX, startY);
            stack.Push(startPoint);
            visited.Add(startPoint);

            int maxPoints = originalBitmap.Width * originalBitmap.Height; // Защита от бесконечного цикла

            while (stack.Count > 0 && borderPoints.Count < maxPoints)
            {
                Point current = stack.Pop();
                borderPoints.Add(current);

                // Добавляем точку в список
                listBoxBorderPoints.Items.Add($"({current.X}, {current.Y})");

                // Ищем соседние граничные точки
                for (int i = 0; i < directions.Length; i++)
                {
                    Point neighbor = new Point(current.X + directions[i].X, current.Y + directions[i].Y);

                    if (IsValidPoint(neighbor) && !visited.Contains(neighbor))
                    {
                        Color neighborColor = originalBitmap.GetPixel(neighbor.X, neighbor.Y);
                        if (neighborColor.ToArgb() == borderColor.ToArgb())
                        {
                            stack.Push(neighbor);
                            visited.Add(neighbor);
                        }
                    }
                }

                // Обновляем отображение каждые 50 точек для визуализации процесса
                if (borderPoints.Count % 50 == 0)
                {
                    UpdateDisplay();
                    Application.DoEvents();
                }
            }

            // Финальное обновление отображения
            UpdateDisplay();

            MessageBox.Show($"Обход границы завершен.\nНайдено точек: {borderPoints.Count}",
                          "Завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsValidPoint(Point point)
        {
            return point.X >= 0 && point.X < originalBitmap.Width &&
                   point.Y >= 0 && point.Y < originalBitmap.Height;
        }

        private void UpdateDisplay()
        {
            // Создаем копию оригинального изображения
            displayBitmap = new Bitmap(originalBitmap);

            // Рисуем найденные граничные точки поверх
            using (Graphics g = Graphics.FromImage(displayBitmap))
            {
                foreach (Point point in borderPoints)
                {
                    g.FillRectangle(new SolidBrush(highlightColor), point.X, point.Y, 1, 1);
                }
            }

            pictureBoxDisplay.Image = displayBitmap;
            pictureBoxDisplay.Refresh();

            // Обновляем информацию о точках
            labelPointsInfo.Text = $"Точки границы ({borderPoints.Count})";
        }

        private void buttonClearBorder_Click(object sender, EventArgs e)
        {
            if (isImageLoaded && originalBitmap != null)
            {
                displayBitmap = new Bitmap(originalBitmap);
                pictureBoxDisplay.Image = displayBitmap;
                borderPoints.Clear();
                listBoxBorderPoints.Items.Clear();
                labelPointsInfo.Text = "Точки границы (0)";
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCreateRectangle_Click(object sender, EventArgs e)
        {
            CreateBlankImage();
            using (Graphics g = Graphics.FromImage(originalBitmap))
            {
                Pen borderPen = new Pen(borderColor, 2);
                // Большой прямоугольник
                g.DrawRectangle(borderPen, 100, 100, 200, 150);
                borderPen.Dispose();
            }
            displayBitmap = new Bitmap(originalBitmap);
            pictureBoxDisplay.Image = displayBitmap;

            borderPoints.Clear();
            listBoxBorderPoints.Items.Clear();
            labelPointsInfo.Text = "Точки границы (0)";
        }

        private void buttonCreateCircle_Click(object sender, EventArgs e)
        {
            CreateBlankImage();
            using (Graphics g = Graphics.FromImage(originalBitmap))
            {
                Pen borderPen = new Pen(borderColor, 2);
                // Большой круг
                g.DrawEllipse(borderPen, 150, 100, 200, 200);
                borderPen.Dispose();
            }
            displayBitmap = new Bitmap(originalBitmap);
            pictureBoxDisplay.Image = displayBitmap;

            borderPoints.Clear();
            listBoxBorderPoints.Items.Clear();
            labelPointsInfo.Text = "Точки границы (0)";
        }

        private void buttonCreateTriangle_Click(object sender, EventArgs e)
        {
            CreateBlankImage();
            using (Graphics g = Graphics.FromImage(originalBitmap))
            {
                Pen borderPen = new Pen(borderColor, 2);
                // Большой треугольник
                Point[] triangle = {
                    new Point(300, 350),
                    new Point(450, 200),
                    new Point(150, 200)
                };
                g.DrawPolygon(borderPen, triangle);
                borderPen.Dispose();
            }
            displayBitmap = new Bitmap(originalBitmap);
            pictureBoxDisplay.Image = displayBitmap;

            borderPoints.Clear();
            listBoxBorderPoints.Items.Clear();
            labelPointsInfo.Text = "Точки границы (0)";
        }

        private void buttonCreateComplex_Click(object sender, EventArgs e)
        {
            CreateBlankImage();
            using (Graphics g = Graphics.FromImage(originalBitmap))
            {
                Pen borderPen = new Pen(borderColor, 2);
                // Комплексная фигура - прямоугольник с кругом внутри
                g.DrawRectangle(borderPen, 80, 80, 300, 200);
                g.DrawEllipse(borderPen, 150, 120, 100, 100);
                borderPen.Dispose();
            }
            displayBitmap = new Bitmap(originalBitmap);
            pictureBoxDisplay.Image = displayBitmap;

            borderPoints.Clear();
            listBoxBorderPoints.Items.Clear();
            labelPointsInfo.Text = "Точки границы (0)";
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            CreateBlankImage();
            borderPoints.Clear();
            listBoxBorderPoints.Items.Clear();
            labelPointsInfo.Text = "Точки границы (0)";
        }
    }
}