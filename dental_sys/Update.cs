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
    public partial class Update : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public Update()
        {
            InitializeComponent();
          //  dtMeetDateU.Value = DateTime.Now;
            dtMeetTime.Value = DateTime.Now;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }

        private void Update_Load(object sender, EventArgs e)
        {

        }

        private void txtBoxVisitorNameU_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateU_Click(object sender, EventArgs e)
        {
          
        }

        private void btnUpdateU_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            bool validupdate = false;
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Visitation_Code", conn);
                da.Fill(dt);
                conn.Close();
               // DateTime time = dtMeetDateU.TodayDate;
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToString(row["Visitor_Name"]) == txtBoxVisitorNameU.Text)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("update Visitation_Code set Meeting_Date = @1, Meeting_Time = @3 where Visitor_Name = @2", conn);

                        cmd.Parameters.AddWithValue("@1", dtMeetDateU.Text);
                        cmd.Parameters.AddWithValue("@2", txtBoxVisitorNameU.Text);
                        cmd.Parameters.AddWithValue("@3", dtMeetTime.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Meeting Updated.");
                        validupdate = true;


                    }
                    else
                    {

                        // conn.Close();

                    }

                }

                // conn.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show("Error Connection:" + f);
            }
            finally
            {
                conn.Close();
            }
            if (validupdate == false)
            {

                MessageBox.Show("Enter correct Visitor Name.");
            }
        }

        private void txtBoxVisitorNameU_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxVisitorNameU.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtBoxVisitorNameU.Text, "^[a-zA-Z]"))
            {
                e.Cancel = true;
                txtBoxVisitorNameU.Focus();
                errorProvider1.SetError(txtBoxVisitorNameU, "Cannot leave field empty or enter numbers");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxVisitorNameU, "");
            }
        }
    }
}
