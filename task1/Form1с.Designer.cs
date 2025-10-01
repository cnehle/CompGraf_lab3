namespace lab2_task1
{
    partial class Form1c
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.listBoxBorderPoints = new System.Windows.Forms.ListBox();
            this.labelPointsInfo = new System.Windows.Forms.Label();
            this.buttonClearBorder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonCreateComplex = new System.Windows.Forms.Button();
            this.buttonCreateTriangle = new System.Windows.Forms.Button();
            this.buttonCreateCircle = new System.Windows.Forms.Button();
            this.buttonCreateRectangle = new System.Windows.Forms.Button();
            this.labelImageInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(20, 40);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(600, 500);
            this.pictureBoxDisplay.TabIndex = 0;
            this.pictureBoxDisplay.TabStop = false;
            this.pictureBoxDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDisplay_MouseDown);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(520, 650);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 30);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(20, 20);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(380, 13);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "Создайте фигуру и щелкните на границе для начала обхода (красный)";
            // 
            // listBoxBorderPoints
            // 
            this.listBoxBorderPoints.FormattingEnabled = true;
            this.listBoxBorderPoints.Location = new System.Drawing.Point(640, 60);
            this.listBoxBorderPoints.Name = "listBoxBorderPoints";
            this.listBoxBorderPoints.Size = new System.Drawing.Size(150, 420);
            this.listBoxBorderPoints.TabIndex = 4;
            // 
            // labelPointsInfo
            // 
            this.labelPointsInfo.AutoSize = true;
            this.labelPointsInfo.Location = new System.Drawing.Point(640, 40);
            this.labelPointsInfo.Name = "labelPointsInfo";
            this.labelPointsInfo.Size = new System.Drawing.Size(96, 13);
            this.labelPointsInfo.TabIndex = 5;
            this.labelPointsInfo.Text = "Точки границы (0)";
            // 
            // buttonClearBorder
            // 
            this.buttonClearBorder.Location = new System.Drawing.Point(20, 650);
            this.buttonClearBorder.Name = "buttonClearBorder";
            this.buttonClearBorder.Size = new System.Drawing.Size(100, 30);
            this.buttonClearBorder.TabIndex = 6;
            this.buttonClearBorder.Text = "Очистить границу";
            this.buttonClearBorder.UseVisualStyleBackColor = true;
            this.buttonClearBorder.Click += new System.EventHandler(this.buttonClearBorder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClearAll);
            this.groupBox1.Controls.Add(this.buttonCreateComplex);
            this.groupBox1.Controls.Add(this.buttonCreateTriangle);
            this.groupBox1.Controls.Add(this.buttonCreateCircle);
            this.groupBox1.Controls.Add(this.buttonCreateRectangle);
            this.groupBox1.Controls.Add(this.labelImageInfo);
            this.groupBox1.Location = new System.Drawing.Point(20, 550);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 90);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создание фигур";
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(650, 25);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(100, 30);
            this.buttonClearAll.TabIndex = 12;
            this.buttonClearAll.Text = "Очистить все";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonCreateComplex
            // 
            this.buttonCreateComplex.Location = new System.Drawing.Point(490, 25);
            this.buttonCreateComplex.Name = "buttonCreateComplex";
            this.buttonCreateComplex.Size = new System.Drawing.Size(140, 30);
            this.buttonCreateComplex.TabIndex = 11;
            this.buttonCreateComplex.Text = "Комплексная фигура";
            this.buttonCreateComplex.UseVisualStyleBackColor = true;
            this.buttonCreateComplex.Click += new System.EventHandler(this.buttonCreateComplex_Click);
            // 
            // buttonCreateTriangle
            // 
            this.buttonCreateTriangle.Location = new System.Drawing.Point(330, 25);
            this.buttonCreateTriangle.Name = "buttonCreateTriangle";
            this.buttonCreateTriangle.Size = new System.Drawing.Size(140, 30);
            this.buttonCreateTriangle.TabIndex = 10;
            this.buttonCreateTriangle.Text = "Треугольник";
            this.buttonCreateTriangle.UseVisualStyleBackColor = true;
            this.buttonCreateTriangle.Click += new System.EventHandler(this.buttonCreateTriangle_Click);
            // 
            // buttonCreateCircle
            // 
            this.buttonCreateCircle.Location = new System.Drawing.Point(170, 25);
            this.buttonCreateCircle.Name = "buttonCreateCircle";
            this.buttonCreateCircle.Size = new System.Drawing.Size(140, 30);
            this.buttonCreateCircle.TabIndex = 9;
            this.buttonCreateCircle.Text = "Круг";
            this.buttonCreateCircle.UseVisualStyleBackColor = true;
            this.buttonCreateCircle.Click += new System.EventHandler(this.buttonCreateCircle_Click);
            // 
            // buttonCreateRectangle
            // 
            this.buttonCreateRectangle.Location = new System.Drawing.Point(10, 25);
            this.buttonCreateRectangle.Name = "buttonCreateRectangle";
            this.buttonCreateRectangle.Size = new System.Drawing.Size(140, 30);
            this.buttonCreateRectangle.TabIndex = 8;
            this.buttonCreateRectangle.Text = "Прямоугольник";
            this.buttonCreateRectangle.UseVisualStyleBackColor = true;
            this.buttonCreateRectangle.Click += new System.EventHandler(this.buttonCreateRectangle_Click);
            // 
            // labelImageInfo
            // 
            this.labelImageInfo.AutoSize = true;
            this.labelImageInfo.Location = new System.Drawing.Point(10, 65);
            this.labelImageInfo.Name = "labelImageInfo";
            this.labelImageInfo.Size = new System.Drawing.Size(120, 13);
            this.labelImageInfo.TabIndex = 7;
            this.labelImageInfo.Text = "Изображение не создано";
            // 
            // Form1c
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 691);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClearBorder);
            this.Controls.Add(this.labelPointsInfo);
            this.Controls.Add(this.listBoxBorderPoints);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Name = "Form1c";
            this.Text = "Задание 1в - Выделение границы области";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ListBox listBoxBorderPoints;
        private System.Windows.Forms.Label labelPointsInfo;
        private System.Windows.Forms.Button buttonClearBorder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelImageInfo;
        private System.Windows.Forms.Button buttonCreateRectangle;
        private System.Windows.Forms.Button buttonCreateCircle;
        private System.Windows.Forms.Button buttonCreateTriangle;
        private System.Windows.Forms.Button buttonCreateComplex;
        private System.Windows.Forms.Button buttonClearAll;
    }
}