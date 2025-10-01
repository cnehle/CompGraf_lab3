using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2_task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTask1a_Click(object sender, EventArgs e)
        {
            Form1a form1a = new Form1a();
            form1a.Show();
            this.Hide();
            form1a.FormClosed += (s, args) => this.Show();
        }

        private void buttonTask1b_Click(object sender, EventArgs e)
        {
            Form1b form1b = new Form1b();
            form1b.Show();
            this.Hide();
            form1b.FormClosed += (s, args) => this.Show();
        }

        private void buttonTask1c_Click(object sender, EventArgs e)
        {
            Form1c form1c = new Form1c();
            form1c.Show();
            this.Hide();
            form1c.FormClosed += (s, args) => this.Show();
        }
    }
}