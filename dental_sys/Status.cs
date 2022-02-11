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
   
    public partial class Status : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public Status()
        {
            InitializeComponent();
            countVisitors();
            viewVisitors();
        }

        public void countVisitors()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select count(Status) AS [Count], Status from Visitor_Status Group by Status", conn);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToString(row["Status"]) == "Not yet Arried")
                    {
                        txtBoxToAriave.Text = row["Count"].ToString();
                    }
                    if (Convert.ToString(row["Status"]) == "Signed In")
                    {
                        txtBoxSignedIn.Text = row["Count"].ToString();
                    }
                    /* if (Convert.ToString(row["Status"]) == "Lobby")
                     {
                         txtBoxLobby.Text = row["Count"].ToString();
                     } */
                    if (Convert.ToString(row["Status"]) == "Meeting")
                    {
                        txtBoxMeeting.Text = row["Count"].ToString();
                    }
                    if (Convert.ToString(row["Status"]) == "Signed Out")
                    {
                        txtBoxSignedOut.Text = row["Count"].ToString();
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
        public void viewVisitors()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {
                //string notYetArried = "Not yet Arried"; 
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select Code_Number AS [Code Number], Status, Visitor_Name AS [Visitor Name], Host_Name AS [Host Name] from Visitor_Status  ", conn); //whre status = yet to arrave
                da.Fill(dt);
                dgStatus.DataSource = dt;
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
    }
}
