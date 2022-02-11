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
    public partial class Cancel : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public string user = login.SetValueForUser;
        
        public Cancel()
        {
            InitializeComponent();
           
            refreshGrid();
           // Create create = new Create(this);
        }

        private void Patient_Load(object sender, EventArgs e)
        {
           
        }
        public void refreshGrid()
        {
            string Notyet = "Not yet Arried";
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select Meeting.Code_Number AS[Code Number], Visiter_Names AS[Visitor Name], Meeting_Purpose AS[Meeting Purpose], Meeting_Date AS [Date], Meeting_Time AS [Time]  from Meeting , Visitation_Code, Visitor_Status WHERE Meeting.Code_Number = Visitation_Code.Code_Number AND Meeting.Code_Number = Visitor_Status.Code_Number AND Status like '%" + Notyet + "%' AND Host_Names like  '%" + user + "%'  ", conn);
                // "select Meeting.Code_Number AS [Code Number], Host_Names AS [Host Name], Visiter_Names AS [Visitor Name], Meeting_Purpose AS [Meeting Purpose], Status  from Meeting , Visitor_Status WHERE Meeting.Code_Number = Visitor_Status.Code_Number AND Status like " + Notyet + " ", conn);
                da.Fill(dt);
                dgCancel.DataSource = dt;
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection:" + e);
            }
            finally
            {
                conn.Close();
            }
            int numbRows = dgCancel.Rows.Count;
            LbCountRows.Text = numbRows.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgCancel.SelectedRows.Count > 0)
            {

                SqlConnection conn = new SqlConnection(myConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Meeting where Code_Number = @1", conn);
                cmd.Parameters.AddWithValue("@1", dgCancel.SelectedCells[0].Value.ToString());
                DialogResult ans = MessageBox.Show("Delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    delVisStatusDA();
                    delVisCodeDA();

                    MessageBox.Show("1 record deleted");
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("No record was deleted.");
                }
              //  refresh();
                refreshGrid();
            }
        }
        private void delVisStatusDA()
        {

            SqlConnection conn = new SqlConnection(myConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Visitor_Status where Code_Number = @1", conn);
            cmd.Parameters.AddWithValue("@1", dgCancel.SelectedCells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void delVisCodeDA()
        {

            SqlConnection conn = new SqlConnection(myConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Visitation_Code where Code_Number = @1", conn);
            cmd.Parameters.AddWithValue("@1", dgCancel.SelectedCells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
