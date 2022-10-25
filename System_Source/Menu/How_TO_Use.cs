using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Station
{
    public partial class How_TO_Use : MetroFramework.Forms.MetroForm
    {
        public How_TO_Use()
        {
            InitializeComponent();
        }

        private void How_TO_Use_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f2 = new Welcome();
            f2.ShowDialog();
            this.Close();
        }
    }
}
