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

    public partial class VisitorsPer : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public VisitorsPer()
        {
            InitializeComponent();
            loadData();
            loadTable();
        }
       // public System.Data.SqlClient.SqlDataReader ExecuteReader();
        private void loadData ()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
           
            //   DataTable dt = new DataTable();
            SqlCommand da = new SqlCommand("select Host_Names AS [Host Name], count(Visitor.Code_Number) AS [Total Visitos]  FROM Visitor,Meeting WHERE Visitor.Code_Number = Meeting.Code_Number GROUP BY Host_Names",conn); //whre status = yet to arrave
            SqlDataReader myReader;
            try
            {
                conn.Open();
                myReader = da.ExecuteReader();

                while (myReader.Read())
                {
                   
                    this.chart1.Series["Visitors"].Points.AddXY(myReader.GetString(0), myReader.GetInt32(1));
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        private void loadTable()
        {

            SqlConnection conn = new SqlConnection(myConnectionString);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Host_Names AS [Host Name], count(Visitor.Code_Number) AS [Total Visitos]  FROM Visitor,Meeting WHERE Visitor.Code_Number = Meeting.Code_Number GROUP BY Host_Names", conn); //whre status = yet to arrave
                                                                                                                                                                                                                                       //  SqlDataReader myReader;
            da.Fill(dt);
            dglist.DataSource = dt;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
    }
