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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string Login = "SELECT * FROM tbl_users WHERE username= '" + textBoxUsername.Text + "' and password= '" + textBoxPassword.Text + "')";
            command = new OleDbCommand(Login, connection);
            OleDbDataReader dataReader = command.ExecuteReader();

            //Condition to check if username and passoword match

            if (dataReader.Read() == true)
            { //if it matches
                new loginSuccess().Show();
                this.Hide();
            }
            else { //Message box to display if credentials are incorrect
                MessageBox.Show("Invalid Username or Password, Please try again !", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
                textBoxUsername.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '•';//masks the password in bullets
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
