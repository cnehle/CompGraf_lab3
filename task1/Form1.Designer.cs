namespace lab2_task1
{
    partial class Form1
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
            this.buttonTask1a = new System.Windows.Forms.Button();
            this.buttonTask1b = new System.Windows.Forms.Button();
            this.buttonTask1c = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonTask1a
            // 
            this.buttonTask1a.Location = new System.Drawing.Point(84, 181);
            this.buttonTask1a.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTask1a.Name = "buttonTask1a";
            this.buttonTask1a.Size = new System.Drawing.Size(267, 49);
            this.buttonTask1a.TabIndex = 0;
            this.buttonTask1a.Text = "Задание 1а";
            this.buttonTask1a.UseVisualStyleBackColor = true;
            this.buttonTask1a.Click += new System.EventHandler(this.buttonTask1a_Click);
            // 
            // buttonTask1b
            // 
            this.buttonTask1b.Location = new System.Drawing.Point(84, 267);
            this.buttonTask1b.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTask1b.Name = "buttonTask1b";
            this.buttonTask1b.Size = new System.Drawing.Size(267, 49);
            this.buttonTask1b.TabIndex = 1;
            this.buttonTask1b.Text = "Задание 1б";
            this.buttonTask1b.UseVisualStyleBackColor = true;
            this.buttonTask1b.Click += new System.EventHandler(this.buttonTask1b_Click);
            // 
            // buttonTask1c
            // 
            this.buttonTask1c.Location = new System.Drawing.Point(84, 354);
            this.buttonTask1c.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTask1c.Name = "buttonTask1c";
            this.buttonTask1c.Size = new System.Drawing.Size(267, 49);
            this.buttonTask1c.TabIndex = 2;
            this.buttonTask1c.Text = "Задание 1в (Границы)";
            this.buttonTask1c.UseVisualStyleBackColor = true;
            this.buttonTask1c.Click += new System.EventHandler(this.buttonTask1c_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(79, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите задание:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 624);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTask1c);
            this.Controls.Add(this.buttonTask1b);
            this.Controls.Add(this.buttonTask1a);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Лабораторная работа 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTask1a;
        private System.Windows.Forms.Button buttonTask1b;
        private System.Windows.Forms.Button buttonTask1c;
        private System.Windows.Forms.Label label1;
    }
}