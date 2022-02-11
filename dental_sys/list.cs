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
using System.Drawing.Imaging;
using System.IO;




namespace dental_sys
{
    public partial class list : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public list()
        {
            InitializeComponent();
            refreshGrid();
        }
        public void refreshGrid()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            DateTime dateTo = Convert.ToDateTime(dtFrom.Text);
            DateTime DateFrom = Convert.ToDateTime(dtTo.Text);
            try
            {
                //string notYetArried = "Not yet Arried"; 
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select Visitation_Code.Code_Number AS [Code Number], Visitor_Name AS [Visitor Name], Meeting_Purpose AS [Meeting purpose], Meeting_Date AS [Meeting Date], Host_Name AS [Host Name] FROM Visitation_Code, Meeting WHERE Visitation_Code.Code_Number = Meeting.Code_Number AND Meeting_Date BETWEEN '" + DateFrom + "' AND  '" + dateTo + "' ", conn); //whre status = yet to arrave
                da.Fill(dt);
                dglist.DataSource = dt;
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

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dglist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.pnlDatefilter.Visible = true;
            refreshGrid();
        }

        private void list_Load(object sender, EventArgs e)
        {
            
        }

        private void list_MouseClick(object sender, MouseEventArgs e)
        {
            this.pnlDatefilter.Visible = false;
            refreshGrid();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int DGVOriginalHeight = dglist.Height;
            dglist.Height = (dglist.RowCount * dglist.RowTemplate.Height) +
                                    dglist.ColumnHeadersHeight;

            using (Bitmap bitmap = new Bitmap(this.dglist.Width, this.dglist.Height))
            {
                dglist.DrawToBitmap(bitmap, new Rectangle(Point.Empty, this.dglist.Size));
                string DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                bitmap.Save(Path.Combine(DesktopFolder, "Visitor list.png"), ImageFormat.Png);
            }
            dglist.Height = DGVOriginalHeight;
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dglist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.pnlDatefilter.Visible = false;
            refreshGrid();
        }

        private void guna2Panel2_MouseClick(object sender, MouseEventArgs e)
        {
            this.pnlDatefilter.Visible = false;
            refreshGrid();
        }

        private void guna2Button2_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void guna2Button2_DoubleClick(object sender, EventArgs e)
        {
            this.pnlDatefilter.Visible = false;
            refreshGrid();
        }
    }
}
