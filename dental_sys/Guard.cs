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
    public partial class Guard : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public Guard()
        {
            InitializeComponent();
            refreshGrid();
            dtSignIn.Value = DateTime.Now;
            dtExit.Value = DateTime.Now;


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
        private void Guard_Load(object sender, EventArgs e)
        {
            container(new Status());
        }
        public void refreshGrid()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            string Out = "Signed Out";
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select Meeting.Code_Number AS[Code Number], Host_Names AS[Host Name], Visiter_Names AS[Visitor Name], Meeting_Purpose AS[Meeting Purpose] from Meeting , Visitor_Status WHERE Meeting.Code_Number = Visitor_Status.Code_Number AND Status Not like '%" + Out + "%'", conn);
                // "select Meeting.Code_Number AS [Code Number], Host_Names AS [Host Name], Visiter_Names AS [Visitor Name], Meeting_Purpose AS [Meeting Purpose], Status  from Meeting , Visitor_Status WHERE Meeting.Code_Number = Visitor_Status.Code_Number AND Status like " + Notyet + " ", conn);
                da.Fill(dt);
                dgNext.DataSource = dt;
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

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           // label_val.Text = "Cancel Meeting";
           // guna2PictureBox_val.Image = Properties.Resources.person__1_;
            container(new Status());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            container(new list());
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(myConnectionString);
            bool blnValidInput = true;
            bool blnValidDate = true;
            DateTime time = Convert.ToDateTime(dtSignIn.Text);
            blnValidInput = ValidateInputForm(blnValidInput);
           // blnValidDate = ValidateDate(blnValidDate);
            if (blnValidInput == true)
            {
                if (blnValidDate == true)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Visitor (Visitor_ID, Visitor_Name, Code_Number, Contact_Number, Entrance_Time, Registration_Plate) values (@1, @2, @3, @4, @5, @6)", conn);
                    cmd.Parameters.AddWithValue("@1", txtID.Text);
                    cmd.Parameters.AddWithValue("@2", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@3", txtCode.Text);
                    cmd.Parameters.AddWithValue("@4", txtContact.Text);
                    cmd.Parameters.AddWithValue("@5", time);
                    cmd.Parameters.AddWithValue("@6", txtPlateNum.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //refreshGrid();
                    MessageBox.Show("Visitor signed in.");
                    changeStatusSignedIn();
                    //send popup

                }
            }

        }
        private bool ValidateInputForm(bool blnValidInput)
        {
            if (txtID.Text == "" /*|| txtID.Text ==*/ || txtFirstName.Text == "" || txtCode.Text == "" || txtPlateNum.Text == "" || txtContact.Text == "")
            {
                MessageBox.Show("Cannot leave empty");
                blnValidInput = false;
            }




            return blnValidInput;
        }
        private bool ValidateDate(bool blnValidDate)
        {
            // DateTime dtSignNow;
            if (dtSignIn.Value < DateTime.Now)
            {
                MessageBox.Show("Date entred cannot be less than current date");
                blnValidDate = false;
            }
            return blnValidDate;
        }
        private void changeStatusSignedIn()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            string SignedIn = "Signed In";
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Visitor_Status set Status = @1 where Code_Number = @2", conn);
            cmd.Parameters.AddWithValue("@1", SignedIn);
            cmd.Parameters.AddWithValue("@2", txtCode.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSignO_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            bool blnValidExitDate = true;
            DateTime time = Convert.ToDateTime(dtExit.Text);
            //  blnValidExitDate = ValidateExitDate(blnValidExitDate);

            if (blnValidExitDate == true)
            {
                bool validupdate = false;
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Visitor", conn);
                    da.Fill(dt);
                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (Convert.ToString(row["Code_Number"]) == txtCodeOut.Text)
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("update Visitor set Exit_Time = @1 where Code_Number = @2", conn);
                            cmd.Parameters.AddWithValue("@1", time);
                            cmd.Parameters.AddWithValue("@2", txtCodeOut.Text);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            // refreshGrid();
                            MessageBox.Show("Visitor signed out");
                            validupdate = true;
                            changeStatusSignOut();
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
                if (validupdate == false)
                {

                    MessageBox.Show("Enter correct visitor name.");
                }
            }

        }
        private void changeStatusSignOut()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            string SignedOut = "Signed Out";
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Visitor_Status set Status = @1 where Code_Number = @2", conn);
            cmd.Parameters.AddWithValue("@1", SignedOut);
            cmd.Parameters.AddWithValue("@2", txtCodeOut.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

        }
        private bool ValidateExitDate(bool blnValidExitDate)
        {
            // DateTime dtSignNow;
            if (dtExit.Value < DateTime.Now)
            {
                MessageBox.Show("Date entred cannot be less than current date") ;
                blnValidExitDate = false;
            }
            return blnValidExitDate;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            container(new VisitorsPer());

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            login f2 = new login();
            this.Visible = false;
            f2.ShowDialog();
        }

        private void blnClearO_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            String Out = "Singed Out";
           // txtCode.Text = txtBoxSearch.Text;
            SqlConnection conn = new SqlConnection(myConnectionString);
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBoxSearch.Text, "[^ 0-9]"))
            {
                txtBoxSearch.Text = "";
            }



            //bool validSearch = false;
            if (txtBoxSearch.Text != "1")
                try
                {
                    if (txtBoxSearch.Text != "")
                    {
                       
                        conn.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter("select Meeting.Code_Number AS[Code Number], Host_Names AS[Host Name], Visiter_Names AS[Visitor Name], Meeting_Purpose AS[Meeting Purpose] from Meeting , Visitor_Status WHERE Meeting.Code_Number = Visitor_Status.Code_Number AND Status Not like '%" + Out + "%' AND Meeting.Code_Number = '" + txtBoxSearch.Text + "' ", conn);

                      //  SqlDataAdapter da = new SqlDataAdapter("select * from Meeting where Code_Number like '%" + txtBoxSearch.Text + "%' ", conn);
                        da.Fill(dt);
                        dgNext.DataSource = dt;
                        //  validSearch = true;
                    }
                    else
                    {
                        refreshGrid();
                        //validSearch = false;
                    }

                }
                catch (Exception g)
                {
                    MessageBox.Show("Error Connection:" + g);
                }
                finally
                {
                    conn.Close();
                }
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, "[^0-9]"))
            {
                e.Cancel = true;
              //  txtID.Focus();
                errorProvider1.SetError(txtID, "Cannot leave field empty or enter letters");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtID, "");
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, "^[a-zA-Z]"))
            {
                e.Cancel = true;
              //  txtFirstName.Focus();
                errorProvider2.SetError(txtFirstName, "Cannot leave field empty or enter numbers");

            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtFirstName, "");
            }
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || System.Text.RegularExpressions.Regex.IsMatch(txtCode.Text, "[^0-9]"))
            {
                e.Cancel = true;
              //  txtCode.Focus();
                errorProvider3.SetError(txtCode, "Cannot leave field empty or enter letters");

            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtCode, "");
            }
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContact.Text) || System.Text.RegularExpressions.Regex.IsMatch(txtContact.Text, "[^0-9]"))
            {
                e.Cancel = true;
             //   txtContact.Focus();
                errorProvider4.SetError(txtContact, "Cannot leave field empty or enter letters");

            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtContact, "");
            }
        }

        private void txtCodeOut_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodeOut.Text) || System.Text.RegularExpressions.Regex.IsMatch(txtCodeOut.Text, "[^0-9]"))
            {
                e.Cancel = true;
               // txtCodeOut.Focus();
                errorProvider5.SetError(txtCodeOut, "Cannot leave field empty or enter letters");

            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(txtCodeOut, "");
            }
        }

        private void dgNext_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFirstName.Text = dgNext.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCodeOut.Text = txtCode.Text = dgNext.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCode.Text = txtContact.Text = txtID.Text = txtFirstName.Text = txtPlateNum.Text = "";
        }
    }
    
}
