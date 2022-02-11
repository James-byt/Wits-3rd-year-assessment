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
    public partial class Host : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public string user = login.SetValueForUser;
        public Host()
        {
            InitializeComponent();
            lblUsername.Text = user;
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {

                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Visitor_Status WHERE Host_Name like '%"+user+"%' ", conn);
                da.Fill(dt);
                conn.Close();

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToString(row["Status"]) == "Signed In")
                    {
                        string title = Convert.ToString(row["Visitor_Name"]);
                        popupCornfirmz(title);

                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("Error Connection:" + f);
            }
            finally
            {
                conn.Close();
            }
        }
        private void popupCornfirmz(string title)
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            string message = "Click yes to confirm your meeting with visitor";
            string txtMeeting = "Meeting";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Visitor_Status set Status = @1 where Visitor_Name = @2 ", conn);
                cmd.Parameters.AddWithValue("@1", txtMeeting);
                cmd.Parameters.AddWithValue("@2", title);
              //  cmd.Parameters.AddWithValue("@3", user);

                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();
               Host f1 = new Host();
                this.Visible = false;
                f1.ShowDialog();
            }
            else
            {
                // Do something  wait in the lobby
            }

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            label_val.Text = "Dashboard Overview";
            guna2PictureBox_val.Image = Properties.Resources.dashboard__12_;
            container(new Dashboard());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label_val.Text = "Dashboard Overview";
            guna2PictureBox_val.Image = Properties.Resources.dashboard__12_;
            container(new Dashboard());
        }

        private void container(object _form)
        {

            if (guna2Panel_container.Controls.Count > 0) guna2Panel_container.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            guna2Panel_container.Controls.Add(fm);
            guna2Panel_container.Tag = fm;
            fm.Show();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            label_val.Text = "Meeting List";
            guna2PictureBox_val.Image = Properties.Resources.person__1_;
            container(new Cancel());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            label_val.Text = "Messages";
            guna2PictureBox_val.Image = Properties.Resources.chat__1_;
            container(new Messages());
        }

        private void guna2Panel_container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            label_val.Text = "Create Meeting";
            guna2PictureBox_val.Image = Properties.Resources.person__1_;
            container(new Create());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            label_val.Text = "Update Meeting";
            guna2PictureBox_val.Image = Properties.Resources.person__1_;
            container(new Update());
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            login f2 = new login();
            this.Visible = false;
            f2.ShowDialog();
        }

        private void guna2Panel_top_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
