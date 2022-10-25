using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;  
namespace Bus_Station
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {

        string pass = ""; 

        public string traveler_email, traveler_password;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        private void roundButton_Click(object sender, EventArgs e)
        {


            Database dataBase = new Database();
            // dataBase.connect(); 
            string query = "INSERT INTO  Traveler  ( PhoneNumber,Traveler_Name,Travler_PassWord,Traveler_EMail,city) VALUES(@PhoneNumber,@Traveler_Name,@Travler_PassWord,@Traveler_EMail,@city) ";
            SqlCommand command = new SqlCommand(query);
            // way to input into DataBase
            command.CommandType = CommandType.Text;
            // to connection DataBase in tabel Traveler
            command.Connection = dataBase.connect();
            // to input Text in TextBox to Save Sql Server 
            command.Parameters.AddWithValue("@PhoneNumber", metroTextBox5.Text);
            command.Parameters.AddWithValue("@Traveler_Name", metroTextBox1.Text);
            command.Parameters.AddWithValue("@Travler_PassWord", metroTextBox2.Text);
            command.Parameters.AddWithValue("@Traveler_EMail", metroTextBox4.Text);
            command.Parameters.AddWithValue("@city", metroComboBox1.Text);
            // command.Parameters.AddWithValue("@date", metroDateTime1.Text);

            command.ExecuteNonQuery();



            Vaild v = new Vaild();

            if (metroTextBox2.Text != metroTextBox3.Text)
            {

                MetroFramework.MetroMessageBox.Show(this, " Your Password was not Identical  ", "Sorry " + metroTextBox1.Text, MessageBoxButtons.OK);

            }
            else if (!v.chechMails(metroTextBox4.Text.ToString()))
            {
                MetroFramework.MetroMessageBox.Show(this, " Your E-Mail not valid ", " Sorry", MessageBoxButtons.OK);

            }
            else if ( !v.checkPhoneNum(metroTextBox5.Text.ToString()))
            {
                MetroFramework.MetroMessageBox.Show(this, " Your Phone not valid ", " Sorry", MessageBoxButtons.OK);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, " Your Register was sucessful  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);

                this.Hide();
                Form5 f5 = new Form5();
                f5.ShowDialog();
                this.Close();
            }
            // dataBase.disconnect();


        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            String query = " select  * from Traveler where Traveler_EMail= '" + metroTextBox9.Text + "' and Travler_PassWord = '" + metroTextBox8.Text + "' ;";
            SqlDataAdapter sda = new SqlDataAdapter(query, database.connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);




            if (dtbl.Rows.Count == 1)
            {

                MetroFramework.MetroMessageBox.Show(this, " Your sign in was sucessful  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);
                traveler_email = metroTextBox9.Text;
                traveler_password = metroTextBox8.Text;
                this.Hide();
                Form5 f5 = new Form5();
                f5.ShowDialog();
                this.Close();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, " Your sign in was fail  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);

            }

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            metroPanel1.Visible = true;
            metroPanel2.Visible = false;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroPanel1.Visible = false;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            String query = " select  * from Traveler where Traveler_Name = '" + metroTextBox7.Text + "' and Traveler_Email = '" + metroTextBox6.Text + "' ;";
            SqlDataAdapter sda = new SqlDataAdapter(query, database.connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {

                MetroFramework.MetroMessageBox.Show(this, " Your sign in was sucessful  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);
                metroPanel1.Visible = false;
                metroPanel2.Visible = true;
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, " Your sign in was fail  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);

            }
            metroPanel1.Visible = false;
            metroPanel2.Visible = true;
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTextBox10_Click(object sender, EventArgs e)
        {
            pass = metroTextBox10.Text.ToString(); 
        }

        private void metroTextBox11_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            metroPanel2.Visible = false;
        }
    }
}
