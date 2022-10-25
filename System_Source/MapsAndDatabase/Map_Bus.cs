using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
//Don't forget
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Data.Common;
using System.Data.SqlClient;

namespace Bus_Station
{
    public partial class Map_Bus : MetroFramework.Forms.MetroForm 
    {
       // SQL mSql = new SQL();

        double distance=0, cost=0;
        GMapRoute route; 
        double lat_from_city, longt_from_city , lat_to_city , longt_to_city; 

        private List<PointLatLng> _points;
        
        //1. Create Overlay
        GMapOverlay markers = new GMapOverlay("markers");
        GMapOverlay routes = new GMapOverlay("routes");

        //create a marker
        GMapMarker marker;
        GMapMarker markerr;
        GMapMarker marker2;
        GMapMarker marker3;
       GMapMarker marker4 ;

        bool follow_The_route=false;
        int count_indicators_of_the_root=0;
        PointLatLng start;
        PointLatLng finish;

        ComboBox comboBox_1 = new ComboBox(); 
        

        public Map_Bus()
        {
            InitializeComponent();
            _points = new List<PointLatLng>();

            ///Controls.Add(comboBox_1);
        }



        private void Map_Bus_Load(object sender, EventArgs e)
        {
           /// GMapProviders.GoogleMap.ApiKey = "AIzaSyA32gvIY8FTOy0mwFNcL9bsdxObPa0JjiI";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map.CacheLocation = @"cache";


            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            

           // GMapProviders.GoogleMap.ApiKey = @"AIzaSyA32gvIY8FTOy0mwFNcL9bsdxObPa0JjiI";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map.CacheLocation = @"cache";


            map.ShowCenter = false;   //To disable red cross
            map.Position = new PointLatLng(30.195601, 31.132839);
           
            map.MinZoom = 0;   //Minimum Zoom level 
            map.MaxZoom = 24; //Maximum Zoom level 
            map.Zoom = 11;  //Current Zoom Level 
            map.AutoScroll = true;
        }


        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadMaps_Click(object sender, EventArgs e)
        {
             
            


           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add2Btn_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            route = new GMapRoute(_points , "MyRoute") ;

            route.Stroke = new Pen(Color.Red, 3);

            
            
            routes.Routes.Add(route);

            distance = Math.Round((route.Distance), 2);
            lblDistance.Text = Math.Round((route.Distance) ,2)+ " Km";
            map.Overlays.Add(routes);
       

        }

        private void lblDistance_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRemoveOverlay_Click(object sender, EventArgs e)
        {
            _points.Clear();
            
            map.Overlays.Remove(routes); 
            map.Overlays.Remove(markers);
            routes.Clear();
            markers.Clear();
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            lblDistance.Text = "[Distance in KM]";
            lblCost.Text = "[Cost in Pounds]";
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            lblCost.Text = Math.Round(Math.Round((route.Distance), 2) * 1.30 , 2) + " Pounds";
            cost = Math.Round(Math.Round((route.Distance), 2) * 1.30 ) ;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            SqlConnection sc = new SqlConnection("Data Source=.;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");
           
            SqlDataAdapter da = new SqlDataAdapter();


            da.InsertCommand = new SqlCommand(" INSERT INTO Traveler_Order VALUES ( @order_id ,@from_city , @to_city  ,@Distance , @cost , @phone_number) ", sc);


            da.InsertCommand.Connection = sc;

            da.InsertCommand.Parameters.Add("order_id", SqlDbType.Int).Value = 2 ; //Need to be updated ,Nour
            da.InsertCommand.Parameters.Add("from_city", SqlDbType.Text).Value = comboBox1.SelectedItem;
            da.InsertCommand.Parameters.Add("to_city", SqlDbType.Text).Value = comboBox2.SelectedItem;
            da.InsertCommand.Parameters.Add("Distance", SqlDbType.Float).Value = distance;
            da.InsertCommand.Parameters.Add("cost", SqlDbType.Float).Value = cost;
            da.InsertCommand.Parameters.Add("phone_number", SqlDbType.Int).Value = 5; //Need to be updated ,Nour

            

            sc.Open();
            da.InsertCommand.ExecuteNonQuery();
            sc.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Menu mp = new Menu();
            this.Hide();
            mp.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtLat1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == 0)
            { lat_to_city = 30.291201; longt_to_city = 31.740620; }
            else if (comboBox2.SelectedIndex == 1)
            { lat_to_city = 30.085960; longt_to_city = 31.351170; }
            else if (comboBox2.SelectedIndex == 2)
            { lat_to_city = 30.072371; longt_to_city = 31.321270; }
            else if (comboBox2.SelectedIndex == 3)
            { lat_to_city = 30.069481; longt_to_city = 31.280790; }
            else if (comboBox2.SelectedIndex == 4)
            { lat_to_city = 30.013651; longt_to_city = 31.208139; }
            //Where TO 
            double lat2 = lat_to_city;
            double longt2 = longt_to_city; 

            map.Position = new PointLatLng(lat2, longt2);


            PointLatLng point = new PointLatLng(lat2, longt2);

            try
            {
                _points.Insert(1, point);
                //Create Custom Marker 
                //Bitmap bmpMarker = (Bitmap)Image.FromFile("images/1.png");

                // marker = new GMarkerGoogle(point, bmpMarker);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_pushpin);


                //2. Add All available markers to that Overlay
                markers.Markers.Add(marker);

                //3. Cover Map with Overlay 
                map.Overlays.Add(markers);

            }
            catch 
            {
                MessageBox.Show("Please Enter Your Position Firstly");
                comboBox2.Text = " ";
            }


            


        }

        private void Add_ComboBox_yourPos_Click(object sender, EventArgs e)
        {
            _points.Clear();
            markers.Clear();

            if (comboBox1.SelectedIndex == 0) 
            { lat_from_city = 30.291201; longt_from_city = 31.740620; }
            else if (comboBox1.SelectedIndex == 1)
            { lat_from_city = 30.085960; longt_from_city = 31.351170; }
            else if (comboBox1.SelectedIndex == 2)
            { lat_from_city = 30.072371; longt_from_city = 31.321270; } 
            else if (comboBox1.SelectedIndex == 3)
            { lat_from_city = 30.069481 ; longt_from_city = 31.280790; }
            else if (comboBox1.SelectedIndex == 4)
            { lat_from_city = 30.013651; longt_from_city = 31.208139; }

            //Traveller Position 
            double lat = lat_from_city;
            double longt = longt_from_city;

            // map.Position = new PointLatLng(lat, longt);

            double lat1    = lat_from_city + .1 , lat2= lat_from_city + .12  , lat3= lat_from_city , lat4= lat_from_city-.1;
            double longt1 = longt_from_city + .012 , longt2= longt_from_city+.2 , longt3= longt_from_city+.3 , longt4= longt_from_city;



            PointLatLng point = new PointLatLng(lat, longt);
            PointLatLng point1 = new PointLatLng(lat1, longt1);
            PointLatLng point2 = new PointLatLng(lat2, longt2);
            PointLatLng point3 = new PointLatLng(lat3, longt3);
            PointLatLng point4 = new PointLatLng(lat4, longt4);

            //_points[0]=(new PointLatLng(lat, longt));
            _points.Insert(0, point);

            //Create Custom Marker 
             Bitmap bmpMarker = (Bitmap)Image.FromFile("images/5.png");
             marker = new GMarkerGoogle(point1, bmpMarker);
             marker2 = new GMarkerGoogle(point2, bmpMarker);
             marker3 = new GMarkerGoogle(point3, bmpMarker);
             marker4 = new GMarkerGoogle(point4, bmpMarker);

            markerr = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin);


            //2. Add All available markers to that Overlay
           // markers.Markers.Add(marker); 
            markers.Markers.Add(markerr);
            markers.Markers.Add(marker);
            markers.Markers.Add(marker2);
            markers.Markers.Add(marker3);
            markers.Markers.Add(marker4);

            //3. Cover Map with Overlay 
            map.Overlays.Add(markers);

            

        } 

       
    }
}
