namespace lab2_task1
{
    partial class Form1b
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonLoadPattern = new System.Windows.Forms.Button();
            this.pictureBoxPattern = new System.Windows.Forms.PictureBox();
            this.labelPatternInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPattern)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(27, 49);
            this.pictureBoxCanvas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(666, 492);
            this.pictureBoxCanvas.TabIndex = 0;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseDown);
            this.pictureBoxCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseMove);
            this.pictureBoxCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseUp);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(582, 578);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(111, 37);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(582, 646);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(111, 37);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(27, 25);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(557, 16);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "ЛКМ - рисовать линии, ПКМ - залить область рисунком. Сначала загрузите паттерн.";
            // 
            // buttonLoadPattern
            // 
            this.buttonLoadPattern.Location = new System.Drawing.Point(13, 25);
            this.buttonLoadPattern.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLoadPattern.Name = "buttonLoadPattern";
            this.buttonLoadPattern.Size = new System.Drawing.Size(104, 54);
            this.buttonLoadPattern.TabIndex = 4;
            this.buttonLoadPattern.Text = "Загрузить паттерн";
            this.buttonLoadPattern.UseVisualStyleBackColor = true;
            this.buttonLoadPattern.Click += new System.EventHandler(this.buttonLoadPattern_Click);
            // 
            // pictureBoxPattern
            // 
            this.pictureBoxPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPattern.Location = new System.Drawing.Point(125, 25);
            this.pictureBoxPattern.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxPattern.Name = "pictureBoxPattern";
            this.pictureBoxPattern.Size = new System.Drawing.Size(133, 123);
            this.pictureBoxPattern.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPattern.TabIndex = 5;
            this.pictureBoxPattern.TabStop = false;
            // 
            // labelPatternInfo
            // 
            this.labelPatternInfo.AutoSize = true;
            this.labelPatternInfo.Location = new System.Drawing.Point(266, 25);
            this.labelPatternInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatternInfo.Name = "labelPatternInfo";
            this.labelPatternInfo.Size = new System.Drawing.Size(228, 48);
            this.labelPatternInfo.TabIndex = 6;
            this.labelPatternInfo.Text = "Паттерн: не загружен\n\nСначала загрузите изображение";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonLoadPattern);
            this.groupBox1.Controls.Add(this.labelPatternInfo);
            this.groupBox1.Controls.Add(this.pictureBoxPattern);
            this.groupBox1.Location = new System.Drawing.Point(30, 553);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(525, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление паттерном";
            // 
            // Form1b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 726);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.pictureBoxCanvas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1b";
            this.Text = "Задание 1б - Заливка рисунком";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPattern)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCanvas;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonLoadPattern;
        private System.Windows.Forms.PictureBox pictureBoxPattern;
        private System.Windows.Forms.Label labelPatternInfo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}