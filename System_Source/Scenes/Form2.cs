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
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();

           // this.StyleManager = metroStyleManager1;
        }

       /* private void InitializeComponent()
        {
            throw new NotImplementedException();
        }*/
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }

        private void metroTile2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
            this.Close();
        }

        

        private void metroComboBox1_DropDown(object sender, EventArgs e)
        {

        }
    }
}
