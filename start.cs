using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace а_ля_фотошоп
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
            
        }

        private void start_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(125, 187, 91);
            this.button_start.BackColor = Color.FromArgb(125, 187, 91);
            Timer t = new Timer();
            t.Interval = 9000;
            t.Tick += new EventHandler(timer1_Tick);
            t.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            (sender as Timer).Stop();
            this.pictureBox1.Visible = false;
            this.pictureBox3.Visible = false;
            this.pictureBox2.Visible = true;
            this.button_start.Visible = true;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
