using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace Bus_Station
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel9_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Database dataBase = new Database();
            //dataBase.connect();
            string query = "INSERT INTO  Driver  ( driver_username,driver_password,phoneNum,driver_email,driver_adress) VALUES(@driver_username,@driver_password,@phoneNum,@driver_email,@driver_adress) ";
            SqlCommand command = new SqlCommand(query);
            // way to input into DataBase
            command.CommandType = CommandType.Text;
            // to connection DataBase in tabel Traveler
            command.Connection = dataBase.connect();
            // to input Text in TextBox to Save Sql Server 
            command.Parameters.AddWithValue("@phoneNum", metroTextBox5.Text);
            command.Parameters.AddWithValue("@driver_username", metroTextBox1.Text);
            command.Parameters.AddWithValue("@driver_password", metroTextBox2.Text);
            command.Parameters.AddWithValue("@driver_email", metroTextBox4.Text);
            command.Parameters.AddWithValue("@driver_adress", metroTextBox7.Text);
            // command.Parameters.AddWithValue("@date", metroDateTime1.Text);

            command.ExecuteNonQuery();
            //dataBase.connection.Close();

            Vaild v = new Vaild();

            if (metroTextBox2.Text != metroTextBox3.Text)
            {

                MetroFramework.MetroMessageBox.Show(this, " Your Password was not Identical  ", "Sorry " + metroTextBox1.Text, MessageBoxButtons.OK);

            }
            else if (!v.chechMails(metroTextBox4.Text.ToString()))
            {
                MetroFramework.MetroMessageBox.Show(this, " Your E-Mail not valid ", " Sorry", MessageBoxButtons.OK);

            }
            else if (!v.checkPhoneNum(metroTextBox5.Text.ToString()))
            {
                MetroFramework.MetroMessageBox.Show(this, " Your Phone not valid ", " Sorry", MessageBoxButtons.OK);
            }
            else
                MetroFramework.MetroMessageBox.Show(this, " Your Register was sucessful  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);

        }
        private void Form3_RegionChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f2= new Welcome();
            f2.ShowDialog();
            this.Close();
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Database database = new Database(); 
            String query = " select  * from Driver where driver_email = '" + metroTextBox9.Text + "' and driver_password = '" + metroTextBox8.Text + "' ;";
            SqlDataAdapter sda = new SqlDataAdapter(query, database.connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {

                MetroFramework.MetroMessageBox.Show(this, " Your sign in was sucessful  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK); 
                this.Hide();
                driver driver_obj = new driver();
                driver_obj.ShowDialog();
                this.Close();             }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, " Your sign in was fail  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);

            }

        }
    }
}
