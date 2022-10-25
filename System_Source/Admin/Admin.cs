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
    public partial class Admin : MetroFramework.Forms.MetroForm
    {
        public Admin()
        {
            InitializeComponent();
            fill_GridVeiw();
            fill_GridVeiw2();
            fill_GridVeiw3();

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void metroTabPage4_Click(object sender, EventArgs e)
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

        public void fill_GridVeiw2()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True"))
            {
                con.Open();
                string query = " select  * from Driver ;";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                metroGrid2.DataSource = dtbl;

            }
        }

        public void fill_GridVeiw3()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True"))
            {
                con.Open();
                string query = " select  * from Bus ;";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                metroGrid3.DataSource = dtbl;

            }
        }
        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectRow = metroGrid1.Rows[index];
            from_loc.Text = selectRow.Cells[1].Value.ToString();
            to_loc.Text = selectRow.Cells[2].Value.ToString();
            phone.Text = selectRow.Cells[5].Value.ToString();
            cost.Text = selectRow.Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
            con.Open();
            string query = "DELETE FROM Traveler_Order where Your_Position = '" + from_loc.Text + "'   ; ";


            SqlCommand comd = new SqlCommand(query, con);
            comd.ExecuteNonQuery();

            con.Close();
            fill_GridVeiw();
            MetroFramework.MetroMessageBox.Show(this, "your order was confirmed succssfully . .", "Thank you", MessageBoxButtons.OK);

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
            con.Open();
            string query = "insert into  Driver ( driver_username , driver_password , phoneNum , driver_email ) values ( '" + Driver_Name.Text + "' ,  '" + Driver_password.Text + "' , '" + Driver_phone.Text + "'    ,  '" + driver_email.Text + "'   ) ;  ";


            SqlCommand comd = new SqlCommand(query, con);
            comd.ExecuteNonQuery();

            con.Close();
            fill_GridVeiw2();
            MetroFramework.MetroMessageBox.Show(this, " driver was Added succssfully . .", "Thank you", MessageBoxButtons.OK);

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Remove_driver_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
            con.Open();
            string query = "DELETE FROM Driver where driver_email  = '" + driver_email.Text + "'   and driver_password =  '" + Driver_password.Text + "' ; ";


            SqlCommand comd = new SqlCommand(query, con);
            comd.ExecuteNonQuery();

            con.Close();
            fill_GridVeiw2();
            MetroFramework.MetroMessageBox.Show(this, " driver was Removed succssfully . .", "Thank you", MessageBoxButtons.OK);

        }

        private void Update_driver_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
            con.Open();
            string query = "UPDATE  Driver SET driver_userName = '" + Driver_Name.Text + "' , driver_password =  '" + Driver_password.Text + "' , phoneNum = '" + Driver_phone.Text + "' , driver_email = '" + driver_email.Text + "'  where driver_id = " + Driver_ID.Text + " ; ";


            SqlCommand comd = new SqlCommand(query, con);
            comd.ExecuteNonQuery();

            con.Close();
            fill_GridVeiw2();
            MetroFramework.MetroMessageBox.Show(this, " driver was Updated succssfully . .", "Thank you", MessageBoxButtons.OK);

        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectRow = metroGrid2.Rows[index];
            Driver_ID.Text = selectRow.Cells[0].Value.ToString();
            Driver_Name.Text = selectRow.Cells[1].Value.ToString();
            Driver_password.Text = selectRow.Cells[2].Value.ToString();
            Driver_phone.Text = selectRow.Cells[5].Value.ToString();
            driver_email.Text = selectRow.Cells[7].Value.ToString(); 



        }

        private void metroTile4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
            con.Open();
            string query = "insert into  Bus ( Bus_num , from_city , to_city) values ( '" + bus_Num.Text + "' ,  '" + bus_from.Text + "' , '" + bus_to.Text + "'     ) ;  ";


            SqlCommand comd = new SqlCommand(query, con);
            comd.ExecuteNonQuery();
               
            con.Close();
            fill_GridVeiw3();
            MetroFramework.MetroMessageBox.Show(this, " driver was Added succssfully . .", "Thank you", MessageBoxButtons.OK);
        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectRow = metroGrid3.Rows[index];
            bus_Num.Text = selectRow.Cells[4].Value.ToString();
            bus_from.Text = selectRow.Cells[3].Value.ToString();
            bus_to.Text = selectRow.Cells[2].Value.ToString();

            metroLabel21.Text = selectRow.Cells[0].Value.ToString();


        }

        private void metroTile6_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
            con.Open();
            string query = "DELETE FROM Bus where Bus_num  = '" + bus_Num.Text + "' and  to_city  = '" + bus_to.Text + "'  ; ";


            SqlCommand comd = new SqlCommand(query, con);
            comd.ExecuteNonQuery();

            con.Close();
            fill_GridVeiw3();
            MetroFramework.MetroMessageBox.Show(this, " driver was Removed succssfully . .", "Thank you", MessageBoxButtons.OK);

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
            con.Open();
            string query = "UPDATE  Bus_num  = '" + bus_Num.Text + "' , from_city =  '" + bus_from.Text + "' , to_city = '" + bus_to.Text + "'  ;  " ;
           // string query = "insert into  Bus ( Bus_num , from_city , to_city) values ( '" + bus_Num.Text + "' ,  '" + bus_from.Text + "' , '" + bus_to.Text + "'     ) ;  ";


            SqlCommand comd = new SqlCommand(query, con);
            comd.ExecuteNonQuery();

            con.Close();
            fill_GridVeiw3();
            MetroFramework.MetroMessageBox.Show(this, " driver was Updated succssfully . .", "Thank you", MessageBoxButtons.OK);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Menu mp = new Menu();
            this.Hide();
            mp.ShowDialog();
            this.Close();
        }
    }
}
