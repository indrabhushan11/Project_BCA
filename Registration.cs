using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Steganography
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }


        String connection = @"Data Source=(LocalDB)\MSSQLLocalDB;
                               AttachDbFilename=C:\Users\Lenovo\Documents\Credentials.mdf;
                               Integrated Security=True;Connect Timeout=30;";

        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (txtRegUsername.Text == "")
            {
                MessageBox.Show("Please Enter the Username ", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegUsername.Focus();
                return;
            }
            if (txtRegPassword.Text == "")
            {
                MessageBox.Show("Please Enter the Password ", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegPassword.Focus();
                return;
            }
            else if (txtRegPassword.Text == txtRegCnfPassword.Text)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(connection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    string register = "INSERT INTO LOGIN VALUES ('" + 
                    txtRegUsername.Text + "','" + txtRegPassword.Text + "' )";
                    cmd = new SqlCommand(register, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Your Account has been Successfully Created", " 
                    Registration Success ", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                    txtRegCnfPassword.Text = "";
                    txtRegPassword.Text = "";
                    txtRegUsername.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show(txtRegUsername.Text + " is already registered ", "
                    Registration Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRegPassword.Text = "";
                    txtRegCnfPassword.Text = "";
                    txtRegUsername.Text = "";
                    txtRegUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", " 
                Registration Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegPassword.Text = "";
                txtRegCnfPassword.Text = "";
                txtRegPassword.Focus();
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender,
                                                                                                     EventArgs e)
        {
            if(checkBoxShowPassword.Checked)
            {
                txtRegPassword.PasswordChar = '\0';
                txtRegCnfPassword.PasswordChar = '\0';
            }
            else
            {
                txtRegPassword.PasswordChar = '•';// alt+7
                txtRegCnfPassword.PasswordChar = '•';
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            txtRegCnfPassword.Text = "";
            txtRegPassword.Text = "";
            txtRegUsername.Text = "";
            txtRegUsername.Focus();
            txtRegPassword.Focus();
            txtRegCnfPassword.Focus();
        }

        


        private void backToLoginLabel_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}
