using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Station
{
    public partial class driver : MetroFramework.Forms.MetroForm
    {
        public driver()
        {
            InitializeComponent();
            fill_GridVeiw();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void driver_Load(object sender, EventArgs e)
        {

        }

        public void fill_GridVeiw()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True"))
            {
                con.Open();
                string query = " select  * from Traveler_Order ;";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                metroGrid1.DataSource = dtbl;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
            con.Open();
            string query = "DELETE FROM Traveler_Order where Your_Position  = '" + from_loc.Text + "'   ; ";


            SqlCommand comd = new SqlCommand(query, con);
            comd.ExecuteNonQuery();

            con.Close();
            fill_GridVeiw();
            MetroFramework.MetroMessageBox.Show(this, "your order was confirmed succssfully . .", "Thank you", MessageBoxButtons.OK);

        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            int index = e.RowIndex;
            DataGridViewRow selectRow = metroGrid1.Rows[index];
            from_loc.Text = selectRow.Cells[1].Value.ToString();
            to_loc.Text = selectRow.Cells[2].Value.ToString();
            phone.Text = selectRow.Cells[3].Value.ToString();
            cost.Text = selectRow.Cells[4].Value.ToString();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
            this.Close();
        }
    }
}
