using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Text2Image;
namespace Steganography
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
      
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Login Button
        /// </summary>

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Validation Function for Credentials
            /// Microsoft Sqlconnection
            /// </summary>
           

            

String cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
                   C:\Users\Lenovo\Documents\Credentials.mdf;Integrated  
                   Security=True;Connect Timeout=30;";

            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please Enter the Username ", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter the Password ", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("SELECT Username, 
                                                  Password FROM Login WHERE Username = 
                                                  @Username AND Password = @Password", conn);

                SqlParameter uName = new SqlParameter("@Username", 
                                                       SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@Password", 
                                                       SqlDbType.VarChar);

                uName.Value = txtUsername.Text.Trim();
                uPassword.Value = txtPassword.Text.Trim();

                cmd.Parameters.Add(uName);
                cmd.Parameters.Add(uPassword);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReaderCommandBehavior.Close
                                                                                                              Connection);




                if (reader.Read() == true)
                {
                    MessageBox.Show("You've Logged in Successfully " +            
                                                                               txtUsername.Text);
                    this.Hide();
                    FrmSteganography form1 = new FrmSteganography();
                    form1.Show();
               }
                else
                {
                    MessageBox.Show("Login Failed ... Try again !", "Login Denied", 
                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                    txtPassword.Focus();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, 
                                                                                    MessageBoxIcon.Error);
            }
        }


        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, 
                                                                                                     EventArgs e)
     

          {
            if (checkBoxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';// alt+7
                txtPassword.PasswordChar = '•';
            }
        }
        private void gunaLabel5_Click(object sender, EventArgs e)
        {
            new Registration().Show();
            this.Hide();
        }
    }
}
