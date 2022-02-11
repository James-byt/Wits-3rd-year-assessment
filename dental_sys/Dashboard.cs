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

namespace dental_sys
{
    public partial class Dashboard : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public string user = login.SetValueForUser;
        public Dashboard()
        {
            InitializeComponent();
            lblUser.Text = user;
            countMonthTotal();
            countAllTime();
            refresh();
            CountToday();
         //  loadData();
            loadGraf();
            countVisitors();

        }
        private void loadGraf()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {
                conn.Open();

                SqlCommand da = new SqlCommand("select datename(MONTH, Meeting_Date) AS [Meeting Date], count(Code_Number) AS [Total Visitos]  FROM Visitation_Code WHERE  Host_Name like  '%" + user + "%'  GROUP BY Meeting_Date ", conn); //whre status = yet to arrave
                SqlDataReader myReader;
                myReader = da.ExecuteReader();

                while (myReader.Read())
                {

                    this.chart1.Series["Meetings"].Points.AddXY(myReader.GetValue(0), myReader.GetInt32(1));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void countVisitors()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select count(Status) AS [Count], Status from Visitor_Status WHERE Host_Name like  '%" + user + "%'  Group by Status", conn);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToString(row["Status"]) == "Not yet Arried")
                    {
                        lblNotYet.Text = row["Count"].ToString();
                    }
                    if (Convert.ToString(row["Status"]) == "Signed In")
                    {
                        lblIn.Text = row["Count"].ToString();
                    }
                    /* if (Convert.ToString(row["Status"]) == "Lobby")
                     {
                         txtBoxLobby.Text = row["Count"].ToString();
                     } */
                    if (Convert.ToString(row["Status"]) == "Meeting")
                    {
                        lblMeeting.Text = row["Count"].ToString();
                    }
                    if (Convert.ToString(row["Status"]) == "Signed Out")
                    {
                        lblOut.Text = row["Count"].ToString();
                    }

                }



            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection:" + e);
            }
            finally
            {
                conn.Close();
            }
        }

       

        
        private void countMonthTotal()
        {

            SqlConnection conn = new SqlConnection(myConnectionString);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" SELECT * FROM Visitation_Code WHERE Host_Name like  '%" + user + "%'  AND datepart(mm, Meeting_Date) = month(getdate())AND datepart(yyyy, Meeting_Date) = year(getdate()) ", conn);
        // "select Meeting.Code_Number AS [Code Number], Host_Names AS [Host Name], Visiter_Names AS [Visitor Name], Meeting_Purpose AS [Meeting Purpose], Status  from Meeting , Visitor_Status WHERE Meeting.Code_Number = Visitor_Status.Code_Number AND Status like " + Notyet + " ", conn);
            da.Fill(dt);
            //dgCancel.DataSource = dt;
            conn.Close();
            int numTotalMonth = dt.Rows.Count;
            lblTotalMonth.Text = numTotalMonth.ToString();
        }
        private void countAllTime()
        {

            SqlConnection conn = new SqlConnection(myConnectionString);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" SELECT * FROM Visitation_Code WHERE Host_Name like  '%" + user + "%'", conn);
            // "select Meeting.Code_Number AS [Code Number], Host_Names AS [Host Name], Visiter_Names AS [Visitor Name], Meeting_Purpose AS [Meeting Purpose], Status  from Meeting , Visitor_Status WHERE Meeting.Code_Number = Visitor_Status.Code_Number AND Status like " + Notyet + " ", conn);
            da.Fill(dt);
            //dgCancel.DataSource = dt;
            conn.Close();
            int numTotalMonth = dt.Rows.Count;
            lblTotalAll.Text = numTotalMonth.ToString();
        }
        private void refresh()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            string NotYet = "Not yet Arried";
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select Visitation_Code.Visitor_Name AS [Visitor Name], Meeting_Time AS [Time] from Visitation_Code,Visitor_Status  WHERE Visitation_Code.Code_Number = Visitor_Status.Code_Number AND Visitation_Code.Host_Name like  '%" + user + "%' AND Status like '%"+ NotYet + "%' AND  datepart(dd, Meeting_Date) = day(getdate()) AND  datepart(mm, Meeting_Date) = month(getdate()) AND  datepart(yyyy, Meeting_Date) = year(getdate()) ", conn);
                // "select Meeting.Code_Number AS [Code Number], Host_Names AS [Host Name], Visiter_Names AS [Visitor Name], Meeting_Purpose AS [Meeting Purpose], Status  from Meeting , Visitor_Status WHERE Meeting.Code_Number = Visitor_Status.Code_Number AND Status like " + Notyet + " ", conn);
                da.Fill(dt);
                dgNextMeet.DataSource = dt;
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection:" + e);
            }
            finally
            {
                conn.Close();
            }
            int numCount = dgNextMeet.Rows.Count;
            lblNewCount.Text = numCount.ToString();

        }
        private void countNew()
        {
            string NotYet = "Not yet Arried";
            SqlConnection conn = new SqlConnection(myConnectionString);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" SELECT * FROM Visitation_Code WHERE Host_Name like  '%" + user + "%' AND Status like '%" + NotYet + "%' ", conn);
            // "select Meeting.Code_Number AS [Code Number], Host_Names AS [Host Name], Visiter_Names AS [Visitor N ame], Meeting_Purpose AS [Meeting Purpose], Status  from Meeting , Visitor_Status WHERE Meeting.Code_Number = Visitor_Status.Code_Number AND Status like " + Notyet + " ", conn);
            da.Fill(dt);
            //dgCancel.DataSource = dt;
            conn.Close();
            int numTotalMonth = dt.Rows.Count;
            lblNewCount.Text = numTotalMonth.ToString();
        }

        private void CountToday()
        {

        }

        private void lblNewMeet_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
