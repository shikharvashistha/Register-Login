using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace src
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            
        }
        //create fields like username and password and save as 2003 acess database
        //create a database in ms acess and put it in bin/debug folder
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");//Connecting database to our system
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPassword.Text == "" || textBoxConfirmPassword.Text == "")
            {
                MessageBox.Show("Fields can't be empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxConfirmPassword.Text == textBoxConfirmPassword.Text)
            {
                connection.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + textBoxUsername.Text + "', '" + textBoxPassword.Text + "')";//send user credintials to the database
                command = new OleDbCommand(register, connection);
                command.ExecuteNonQuery();
                connection.Close();

                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
                textBoxConfirmPassword.Text = "";

                //Confirmation text
                MessageBox.Show("Your account has been sucessfully created", "Registration Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { //user input doesn't meet the conditions
                MessageBox.Show("Password doesn't match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Text = "";
                textBoxConfirmPassword.Text = "";
                textBoxPassword.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxConfirmPassword.Text = "";
            textBoxUsername.Focus();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
                textBoxConfirmPassword.PasswordChar = '\0';
            }
            else {
                textBoxPassword.PasswordChar = '•';//masks the password in bullets
                textBoxConfirmPassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Hide();
        }
    }
}
