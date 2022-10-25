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
    public partial class Passanger : MetroFramework.Forms.MetroForm
    {

        string pass = "";

        public string traveler_email, traveler_password, ad_1, ad_2;
        public Passanger()
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
            Welcome f2 = new Welcome();
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
                Menu f5 = new Menu();
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

            if (metroTextBox9.Text.ToString() == "admin" && metroTextBox8.Text.ToString() == "admin")
            {

                MetroFramework.MetroMessageBox.Show(this, " Your sign in was successful  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);
                this.Hide();
                Admin admin = new Admin();
                admin.ShowDialog();
                admin.Close();
            
            }
            else
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
                    Menu f5 = new Menu();
                    f5.ShowDialog();
                    this.Close();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, " Your sign in was fail  ", "Welcome " + metroTextBox1.Text, MessageBoxButtons.OK);

                }
            }

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            metroPanel1.Visible = true;
           // metroPanel1.Visible = false;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroPanel1.Visible = false;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if(metroTextBox10.Text.ToString()== metroTextBox11.Text.ToString())
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
                con.Open();
                string query = "UPDATE  Traveler SET Travler_PassWord = '" + metroTextBox11.Text + "' where Traveler_Name = '"+ metroTextBox7.Text+ "' and Traveler_EMail = '" + metroTextBox6.Text + "'   ";


                SqlCommand comd = new SqlCommand(query, con);
                comd.ExecuteNonQuery();
                MetroFramework.MetroMessageBox.Show(this, " ", " Your Password is updated ", MessageBoxButtons.OK);

                this.Hide();
                Menu f5 = new Menu();
                f5.ShowDialog();
                this.Close();

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "   ", " Your password is indentical", MessageBoxButtons.OK);

            }
        }

        private void metroTextBox11_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
           

            Database database = new Database();
            String query = " select  * from Traveler where Traveler_Name = '" + metroTextBox7.Text + "' and Traveler_EMail = '" + metroTextBox6.Text + "' ;";
            SqlDataAdapter sda = new SqlDataAdapter(query, database.connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
                metroPanel1.Visible = false;
                metroPanel2.Visible = true; 
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, " Your Name or E-mail isn't valid  ", "Sorry  " , MessageBoxButtons.OK);

            }
        }

        private void metroTextBox9_Click(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            metroPanel2.Visible = false;
        }
    }
}
