using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MALRater.Forms
{
    public partial class LoginWindow : Form
    {
        string username => usernameBox.Text;
        string password => passwordBox.Text;

        public LoginWindow()
        {
            InitializeComponent();
        }

        void loginButton_Click_1(object sender, EventArgs e)
        {
            Login();
        }

        void Enter_Pressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Login();
        }

        void Login()
        {
            UseWaitCursor = true;
            loginButton.Enabled = false;
            passwordBox.ReadOnly = true;
            usernameBox.ReadOnly = true;

            try
            {
                MainWindow.Client = new AnimeClient(username, password);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                UseWaitCursor = false;
                loginButton.Enabled = true;
                passwordBox.ReadOnly = false;
                usernameBox.ReadOnly = false;

                MessageBox.Show("Login failed!");
            }
        }
    }
}
