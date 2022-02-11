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
    public partial class login : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public static String SetValueForUser = "";
        public login()
        {
            InitializeComponent();
           txtBoxUsername.Text = Register.SetValueName;
           txtBoxPassword.Text = Register.SetValuePass;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SetValueForUser = txtBoxUsername.Text;
            // Loading _load = new Loading();
            // _load.Show();

            bool intValid = true;

            if (txtBoxUsername.Text == "")
            {
                MessageBox.Show("PLease enter your Username ", "Error");
                intValid = false;
            }
            if (txtBoxPassword.Text == "")
            {
                MessageBox.Show("PLease enter your password ", "Error");
                intValid = false;
            }
            if (intValid == true)
            {
                String Username = txtBoxUsername.Text;
                String password = txtBoxPassword.Text;

                SqlConnection conn = new SqlConnection(myConnectionString);
                conn.Open();
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Host, Security_Guard", conn);
                    da.Fill(dt);


                   bool correctD = false;
                    bool cD = false;


                    foreach (DataRow row in dt.Rows)
                    {
                        if (Convert.ToString(row["Username_h"]) == Username && row["Password_h"].ToString() == password)
                        {

                            Host _load = new Host();
                            this.Visible = false;
                            _load.ShowDialog();
                        }
                        else if (Convert.ToString(row["Username_h"]) != Username || row["Password_h"].ToString() != password)
                        {

                            correctD = false;
                        }


                    }


                    foreach (DataRow row in dt.Rows)
                    {
                        if (Convert.ToString(row["Username_g"]) == Username && row["Password_g"].ToString() == password)
                        {
                            //move from login to Guard
                            // declare a new instance

                            Guard f1 = new Guard();
                            //make the current form invisible
                            this.Visible = false;
                            //show the new instance 
                            f1.ShowDialog();
                        }
                        else if (Convert.ToString(row["Username_g"]) != Username || row["Password_g"].ToString() != password)
                        {
                            cD = false;

                        }


                    }

                    if (cD == false || correctD == false)
                    {
                        MessageBox.Show("Incorrect username or password ", "Login Unsuccessful");
                    }

                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error Connection:" + ee);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Register f1 = new Register();
            this.Visible = false;
            f1.ShowDialog();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
