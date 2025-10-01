using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace lab2_task1
{
    public partial class Form1b : Form
    {
        private Bitmap bitmap;
        private Bitmap patternBitmap;
        private Color borderColor = Color.Black;
        private Point startPoint;
        private Point previousPoint;
        private bool isDrawing = false;
        private bool isPatternLoaded = false;

        public Form1b()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBoxCanvas.Width, pictureBoxCanvas.Height);
            ClearCanvas();
            pictureBoxCanvas.Image = bitmap;
        }

        private void ClearCanvas()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
            }
            pictureBoxCanvas.Refresh();
        }

        private void buttonLoadPattern_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Выберите изображение для заливки";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    patternBitmap = new Bitmap(openFileDialog.FileName);
                    isPatternLoaded = true;

                    // Показываем превью паттерна
                    pictureBoxPattern.Image = patternBitmap;
                    labelPatternInfo.Text = $"Паттерн: {Path.GetFileName(openFileDialog.FileName)}\n" +
                                          $"Размер: {patternBitmap.Width}x{patternBitmap.Height}";

                    MessageBox.Show($"Паттерн загружен успешно!\nРазмер: {patternBitmap.Width}x{patternBitmap.Height}",
                                  "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isPatternLoaded = false;
                }
            }
        }

        private void pictureBoxCanvas_MouseDown(object sender, MouseEventArgs e)
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
                pictureBoxCanvas.Refresh();
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Запускаем заливку рисунком
                isDrawing = false;

                if (!isPatternLoaded)
                {
                    MessageBox.Show("Сначала загрузите паттерн для заливки!",
                                  "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                startPoint = e.Location;
                FloodFillWithPattern(startPoint.X, startPoint.Y);
            }
        }

        private void pictureBoxCanvas_MouseMove(object sender, MouseEventArgs e)
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
                pictureBoxCanvas.Refresh();
            }
        }

        private void pictureBoxCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void FloodFillWithPattern(int x, int y)
        {
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return;

            Color targetColor = bitmap.GetPixel(x, y);

            if (targetColor.ToArgb() == borderColor.ToArgb())
                return;

            int left = x;
            while (left > 0 && bitmap.GetPixel(left - 1, y).ToArgb() == targetColor.ToArgb())
            {
                left--;
            }

            int right = x;
            while (right < bitmap.Width - 1 && bitmap.GetPixel(right + 1, y).ToArgb() == targetColor.ToArgb())
            {
                right++;
            }

            for (int i = left; i <= right; i++)
            {
                Color patternColor = GetPatternColor(i, y);
                bitmap.SetPixel(i, y, patternColor);
            }

            pictureBoxCanvas.Refresh();
            Application.DoEvents();

            for (int i = left; i <= right; i++)
            {
                if (y > 0 && bitmap.GetPixel(i, y - 1).ToArgb() == targetColor.ToArgb())
                {
                    FloodFillWithPattern(i, y - 1);
                }
                if (y < bitmap.Height - 1 && bitmap.GetPixel(i, y + 1).ToArgb() == targetColor.ToArgb())
                {
                    FloodFillWithPattern(i, y + 1);
                }
            }
        }

        private Color GetPatternColor(int x, int y)
        {
            if (!isPatternLoaded || patternBitmap == null)
                return Color.Gray;

            int patternX = x % patternBitmap.Width;
            int patternY = y % patternBitmap.Height;

            if (patternX < 0) patternX += patternBitmap.Width;
            if (patternY < 0) patternY += patternBitmap.Height;

            return patternBitmap.GetPixel(patternX, patternY);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearCanvas();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}