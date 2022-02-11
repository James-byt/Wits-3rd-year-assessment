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
    public partial class Create : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        //  public Cancel _cancel;
        public string user = login.SetValueForUser;
        public Create()
        {

            InitializeComponent();
            // _cancel = cancel;
            txtBoxHostName.Text = user;
            dtMeetDateE.Value = DateTime.Now;
            dtMeetTime.Value = DateTime.Now;
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (txtBoxVisitorName.Text != "" && txtBoxHostName.Text != "" && txtBoxPurpose.Text != "")
            {

                Random _random = new Random();


                int code = _random.Next(100000, 999999);


                txtBoxCodeNumber.Text = Convert.ToString(code);
            }
            else
            {
                MessageBox.Show("Please enter details first.");
            }
        }

        private void Create_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
           
        }
        public void visitationStatus()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("insert into Visitor_Status (Code_Number, Status, Visitor_Name, Host_Name) values (@1, @2, @3, @4)", conn);
            cmd1.Parameters.AddWithValue("@1", txtBoxCodeNumber.Text);
            cmd1.Parameters.AddWithValue("@2", "Not yet Arried");
            cmd1.Parameters.AddWithValue("@3", txtBoxVisitorName.Text);
            cmd1.Parameters.AddWithValue("@4", txtBoxHostName.Text);
            cmd1.ExecuteNonQuery();
            conn.Close();

        }
        public void visitationCode()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);

            conn.Open();
            SqlCommand cmd1 = new SqlCommand("insert into Visitation_Code (Code_Number, Meeting_Date, Visitor_name, Host_Name, Meeting_Time) values (@1, @2, @3, @4, @5)", conn);
            cmd1.Parameters.AddWithValue("@1", txtBoxCodeNumber.Text);

            cmd1.Parameters.AddWithValue("@2", dtMeetDateE.Text);
            cmd1.Parameters.AddWithValue("@3", txtBoxVisitorName.Text);
            cmd1.Parameters.AddWithValue("@4", txtBoxHostName.Text);
            cmd1.Parameters.AddWithValue("@5", dtMeetTime.Text);
            cmd1.ExecuteNonQuery();
            conn.Close();


        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            if (txtBoxCodeNumber.Text != "")
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Meeting (Host_Names, Visiter_Names, Code_Number, Meeting_Purpose) values (@1, @2, @3, @4)", conn);
                cmd.Parameters.AddWithValue("@1", txtBoxHostName.Text);
                cmd.Parameters.AddWithValue("@2", txtBoxVisitorName.Text);
                cmd.Parameters.AddWithValue("@3", txtBoxCodeNumber.Text);
                cmd.Parameters.AddWithValue("@4", txtBoxPurpose.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                visitationCode();
                visitationStatus();
                // refresh();

                MessageBox.Show("Meeting Created.");
            }
            else
            {

                MessageBox.Show("Please generate code first.");
            }
        }

        private void txtBoxHostName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBoxHostName_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxHostName_Validated(object sender, EventArgs e)
        {

        }

        private void txtBoxHostName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxHostName.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtBoxHostName.Text, "^[a-zA-Z]"))
            {
                e.Cancel = true;
                txtBoxHostName.Focus();
                errorProvider1.SetError(txtBoxHostName, "Cannot leave field empty or enter numbers");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBoxHostName, "");
            }
        }

        private void txtBoxVisitorName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxVisitorName.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtBoxVisitorName.Text, "^[a-zA-Z]"))
            {
                e.Cancel = true;
                txtBoxVisitorName.Focus();
                errorProvider2.SetError(txtBoxVisitorName, "Cannot leave field empty or enter numbers");

            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtBoxVisitorName, "");
            }
        }

        private void txtBoxPurpose_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxPurpose.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtBoxPurpose.Text, "^[a-zA-Z]"))
            {
                e.Cancel = true;
                txtBoxPurpose.Focus();
                errorProvider3.SetError(txtBoxPurpose, "Cannot leave field empty or enter numbers");

            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtBoxPurpose, "");
            }
        }

        private void txtBoxCodeNumber_Validating(object sender, CancelEventArgs e)
        {
            if ( System.Text.RegularExpressions.Regex.IsMatch(txtBoxCodeNumber.Text, "[^0-9]"))
            {
                e.Cancel = true;
                txtBoxCodeNumber.Focus();
                errorProvider3.SetError(txtBoxCodeNumber, "Code must be 5 digits minimum");

            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtBoxCodeNumber, "");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtBoxCodeNumber.Text = txtBoxPurpose.Text = txtBoxVisitorName.Text = "";
        }
    }
}
