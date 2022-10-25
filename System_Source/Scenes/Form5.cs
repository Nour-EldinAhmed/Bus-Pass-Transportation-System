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
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        public Form4 f4 = new Form4();
        public Form5()
        {
            
            InitializeComponent();
            Database datebase = new Database();
            datebase.connect();
            string qurey = " Select * from Traveler where Traveler_EMail  = '" + f4.traveler_email + " '  and Travler_PassWord =  '" + f4.traveler_password + " ' ";

            SqlDataAdapter sda = new SqlDataAdapter(qurey, datebase.connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            metroLabel2.Text = dtbl.Rows[0][1].ToString();

            Name_Edit.Text = dtbl.Rows[0][1].ToString();

            Phone_Edit.Text = dtbl.Rows[0][0].ToString();

            metroTextBox3.Text = dtbl.Rows[0][4].ToString();


            metroTextBox4.Text = f4.traveler_email;

            datebase.disconnect();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.button1.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.BorderSize = 0;
            step1.Location = new Point(1200, 120);
            step2.Location = new Point(1200, 90);
            step3.Location = new Point(1200, 60);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void roundButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //step1.Location = new Point(180, 57);
            //step2.Location = new Point(180, 57);
            //step3.Location = new Point(180, 57);
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(142, 188, 0);
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(17, 17, 17);
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_MouseHover_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(142, 188, 0);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(142, 188, 0);
        }

        private void button4_MouseHover_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(142, 188, 0);
        }

        private void button4_MouseLeave_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("the number of Your Trips is:");
            MetroFramework.MetroMessageBox.Show(this, "the number of Your Trips is:", "Thank you", MessageBoxButtons.OK);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            profile.Visible = true;
            profile.Location = new Point(200, 20);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            profile.Visible = false; 
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Name_Edit.ReadOnly = false;

            Database db = new Database();
            string query = "UPDATE  Traveler SET Traveler_Name =  '" + Name_Edit.Text + "'  where Traveler_EMail  = '" + f4.traveler_email + " '  and Travler_PassWord =  '" + f4.traveler_password + " ' "  ; 

            SqlCommand comd = new SqlCommand(query, db.connection);
            comd.ExecuteNonQuery();
            db.disconnect();

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, Name_Edit.Text, "Thank you", MessageBoxButtons.OK);
            Name_Edit.ReadOnly = true;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Phone_Edit.ReadOnly = false;

            Database db = new Database();
            string query = "UPDATE  Traveler SET Phone_Number =  '" + Phone_Edit.Text + "'  ;";

            SqlCommand comd = new SqlCommand(query, db.connection);
            comd.ExecuteNonQuery();
            db.disconnect();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            metroTextBox3.ReadOnly = false;

            Database db = new Database();
            string query = "UPDATE  Traveler SET City =  '" + City_Edit.Text + "'  ;";

            SqlCommand comd = new SqlCommand(query, db.connection);
            comd.ExecuteNonQuery();
            db.disconnect();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroTextBox4.ReadOnly = false;

            Database db = new Database();
            string query = "UPDATE  Traveler SET Traveler_Email =  '" + Email_Edit.Text + "'  ;";

            SqlCommand comd = new SqlCommand(query, db.connection);
            comd.ExecuteNonQuery();
            db.disconnect();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, Phone_Edit.Text, "Thank you", MessageBoxButtons.OK);
            Phone_Edit.ReadOnly = true;
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, metroTextBox3.Text, "Thank you", MessageBoxButtons.OK);
            metroTextBox3.ReadOnly = true;
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, metroTextBox4.Text, "Thank you", MessageBoxButtons.OK);
            metroTextBox4.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this,"Cash", "Payment System", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            Map_Bus f5 = new Map_Bus();
            f5.ShowDialog();
            this.Close();*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            step1.Location = new Point(230, 57);
            step2.Location = new Point(1200, 90);
            step3.Location = new Point(1200, 60);
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            step2.Location = new Point(230, 57);
            step1.Location = new Point(1200, 120);
            step3.Location = new Point(1200, 60);
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            step3.Location = new Point(230, 57);
            step2.Location = new Point(1200, 90);
            step1.Location = new Point(1200, 120);
        }

        private void metroButton11_MouseClick(object sender, MouseEventArgs e)
        {
            //step2.Visible = true;
            //step1.Visible = false;
            //step2.Location = new Point(100, 57);
        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }

        private void step1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            Map_Bus mp = new Map_Bus();
            this.Hide();
            mp.ShowDialog();
            this.Close();

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
