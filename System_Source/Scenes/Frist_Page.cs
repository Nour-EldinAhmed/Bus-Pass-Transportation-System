using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Station
{
    public partial class Frist_Page : MetroFramework.Forms.MetroForm
    {
        public Frist_Page()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timeLeft = 50;
            timer1.Start();
          //  this.ControlBox = false; 
        }
        public int timeLeft { get; set; }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
            }
            else
            {

                timer1.Stop();
                new Welcome().ShowDialog();
                this.Close(); 
       
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
