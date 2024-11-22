using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mebel
{
    public partial class Autorization : Form
    {
        private string correctUsername = "USER";
        private string correctPassword = "User1234";

        public Autorization()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = LoginBox.Text;
            string password = PasswordBox.Text;

            if (username == correctUsername && password == correctPassword)
            {
                MessageBox.Show("Вход выполнен успешно");
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                LoginBox.Clear();
                PasswordBox.Clear();
            }
        }

        private void LoginBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
