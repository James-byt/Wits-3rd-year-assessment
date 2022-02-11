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
    public partial class Register : Form
    {
        public string myConnectionString = "Data Source=DESKTOP-QMIE1ES;Initial Catalog=viewing;Integrated Security=True";
        public static string SetValueName = "";
        public static string SetValuePass = "";
        public Register()
        {
            InitializeComponent();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            SetValueName = txtSurname.Text;
            SetValuePass = txtPassword.Text;
            bool intValid = true;
            if (txtHostNames.Text == "")
            {
                MessageBox.Show("Please enter your student number  ", "Error");
                intValid = false;
            }
            if (txtSurname.Text == "")
            {
                MessageBox.Show("Please enter your first name ", "Error");
                intValid = false;
            }
            if (txtDepart.Text == "")
            {
                MessageBox.Show("Please enter your last name ", "Error");
                intValid = false;
            }
            if (txtContact.Text == "")
            {
                MessageBox.Show("Please enter your email ", "Error");
                intValid = false;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter your password ", "Error");
                intValid = false;
            }
            if (txtMail.Text == "")
            {
                MessageBox.Show("Please confirm your password ", "Error");
                intValid = false;
            }
            if (intValid == true)
            {

                if (txtPassword.Text != txtCornfirm.Text)
                {
                    MessageBox.Show("Passwords do not match");
                }

                else
                {
                    /*
                                        Random _random = new Random();

                                        int code = _random.Next(10000, 90000);

                                        var smtpClient = new SmtpClient("smtp.gmail.com")
                                        {
                                            Port = 587,
                                            Credentials = new NetworkCredential("Stuport.CyberInk@gmail.com", "Stuport#123"),
                                            EnableSsl = true,
                                        };

                                        var mailMessage = new MailMessage
                                        {
                                            From = new MailAddress("Stuport.CyberInk@gmail.com"),
                                            Subject = "#Stuport Verification",
                                            Body = "<h1>Your Verification Number is : " + code + "</h1>"
                                            + "<br></br>"
                                            + "<br></br>"
                                            + "<br></br>"
                                            + "<h2>Powered by Cyber-Ink</h2>",
                                            IsBodyHtml = true,
                                        };
                                        mailMessage.To.Add(txtBoxEmail.Text);

                                        try
                                        {
                                            smtpClient.Send(mailMessage);
                                        }
                                        catch (SmtpFailedRecipientException ex)
                                        {
                                            MessageBox.Show(ex.ToString());
                                        }

                                        string input = Microsoft.VisualBasic.Interaction.InputBox("Verication Code: ", "Verification Email", "", 0, 0);
                                        if (input == "")
                                        {
                                            MessageBox.Show("Verification invalid", "Invalid Code");
                                        }
                                        else if (code == Convert.ToInt32(input))
                                        {
                                            */

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Host (Host_names, Username_h, Department, Email_Adress, Password_h, Contact_Number, Working_hours) values (@1, @2, @3, @4, @5, @6, @7)", conn);
                    cmd.Parameters.AddWithValue("@1", txtHostNames.Text);
                    cmd.Parameters.AddWithValue("@2", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@3", txtDepart.Text);
                    cmd.Parameters.AddWithValue("@4", txtMail.Text);
                    cmd.Parameters.AddWithValue("@5", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@6", txtContact.Text);
                    cmd.Parameters.AddWithValue("@7", txtWorking.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    /*
                        User.loginID = Convert.ToInt32(txtBoxStudNo.Text);
                        User.email = txtBoxEmail.Text;
                        User.password = txtBoxPass.Text; */


                    MessageBox.Show("Your verified and Registratered successfull.");
                    //move from login to registration
                    //declare a new instance
                    login f1 = new login();
                    //make the current form invisible
                    this.Visible = false;
                    //show the new instance 
                    f1.ShowDialog();

                }
            }
        }

        private void txtHostNames_TextChanged(object sender, EventArgs e)
        {
            txtSurname.Text = txtHostNames.Text;
        }

        private void txtMail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if ( string.IsNullOrWhiteSpace(txtMail.Text) || !rEMail.IsMatch(txtMail.Text))
            {
               
                    txtMail.Focus();
                    errorProvider5.SetError(txtMail, "Please enter valid email");
                   /*  MessageBox.Show("Valid E-Mail expected", "Error", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                       txtMail.SelectAll();
                       e.Cancel = true; */
             

            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(txtMail, "");
            }


        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            login f2 = new login();
            this.Visible = false;
            f2.ShowDialog();
        }

        private void txtHostNames_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHostNames.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtHostNames.Text, "^[a-zA-Z]"))
            {
                e.Cancel = true;
                txtHostNames.Focus();
                errorProvider1.SetError(txtHostNames, "Cannot leave field empty or enter numbers");
                
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtHostNames, "");
            }
           
         
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContact.Text) || System.Text.RegularExpressions.Regex.IsMatch(txtContact.Text, "[^ 0-9]"))
            {
                e.Cancel = true;
                txtContact.Focus();
                errorProvider4.SetError(txtContact, "Cannot leave field empty or enter letters");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtContact, "");
            }

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtSurname.Text, "^[a-zA-Z]") )
            {
                e.Cancel = true;
                txtSurname.Focus();
                errorProvider1.SetError(txtSurname, "Cannot leave field empty or enter numbers");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSurname, "");
            }
          
        }

        private void txtDepart_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepart.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtDepart.Text, "^[a-zA-Z]"))
            {
                e.Cancel = true;
                txtDepart.Focus();
                errorProvider1.SetError(txtDepart, "Cannot leave field empty or enter numbers");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDepart,"");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if ( txtPassword.Text.Length < 4)
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider3.SetError(txtPassword, "Password length must have atleast 4 characters ");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtPassword, "");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtWorking_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
