using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WFA_Lab_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int satid = int.Parse(tbox_sataliteID.Text);
            string satname = tboxSNAME.Text;
            int longitite = int.Parse(tboxLongi.Text);
            int latitute = int.Parse(tboxLatitude.Text);
            float elevation = int.Parse(tboxElivation.Text);
            string health = txbhealth.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\OneDrive\Documents\c#\Database.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string qry = "UPDATE satalite SET satid='" + satid + "',satname='" + satname + "',longitite='" + longitite + "',latitute='" + latitute + "',elevation='" + elevation + "',health='" + health + "' from satalite WHERE satid = " + satid + " ";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            
            string Query = "select * from satalite ";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            DataSet set = new DataSet();
            
            adapter.Fill(set, "satalite");
            dataGridView1.DataSource = set.Tables["satalite"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int satid = int.Parse(tbox_sataliteID.Text);
            string satname = tboxSNAME.Text;
            int longitite = int.Parse(tboxLongi.Text);
            int latitute = int.Parse(tboxLatitude.Text);
            float elevation = int.Parse(tboxElivation.Text);
            string health = txbhealth.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\OneDrive\Documents\c#\Database.mdf;Integrated Security=True;Connect Timeout=30");




            try
            {
                con.Open();
                string query = "INSERT INTO satalite values (" + satid + ", '" + satname + "'," + longitite + "," + latitute + "," + elevation + ",'" + health + "')";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Values added Successfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.ToString());
            }
            string Query = "select * from satalite ";

            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            DataSet set = new DataSet();

            adapter.Fill(set, "satalite");
            dataGridView1.DataSource = set.Tables["satalite"];
        }

        private void Updatetable()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void tbox_sataliteID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbox_sataliteID.Text = "";
            tboxSNAME.Text = "";
            tboxLongi.Text = "";
            tboxLatitude.Text = "";
            tboxElivation.Text = "";
            txbhealth.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\OneDrive\Documents\c#\Database.mdf;Integrated Security=True;Connect Timeout=30");
            int satid = int.Parse(tbox_sataliteID.Text);
            con.Open();
            String del = "DELETE FROM  satalite where satid =" + satid + "";
            SqlCommand cmd = new SqlCommand(del, con);
            cmd.ExecuteNonQuery();
            string Query = "select * from satalite ";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            DataSet set = new DataSet();

            adapter.Fill(set, "satalite");
            dataGridView1.DataSource = set.Tables["satalite"];

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            if (tbox_sataliteID.Text != "")
            { 

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\OneDrive\Documents\c#\Database.mdf;Integrated Security=True;Connect Timeout=30");
                 SqlCommand cmd = new SqlCommand("SELECT satid,satname,longitite,latitute,elevation,health from satalite where satid = @satid", con);
                con.Open();
                cmd.Parameters.AddWithValue("@satid", int.Parse(tbox_sataliteID.Text));
                SqlDataReader da = cmd.ExecuteReader();
                 while (da.Read())
            {
                tboxSNAME.Text = da.GetValue(1).ToString();
                tboxLongi.Text = da.GetValue(2).ToString();
                tboxLatitude.Text = da.GetValue(3).ToString();
                tboxElivation.Text = da.GetValue(4).ToString();
                txbhealth.Text = da.GetValue(5).ToString();
            }
                con.Close();
            }
        }
    }
}
