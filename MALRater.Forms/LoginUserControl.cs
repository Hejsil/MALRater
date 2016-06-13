using System;
using System.Windows.Forms;
using static MALRater.Forms.MainWindow;

namespace MALRater.Forms
{
    public partial class LoginUserControl : UserControl
    {
        string username { get { return usernameBox.Text; } }
        string password { get { return passwordBox.Text; } }

        public LoginUserControl()
        {
            InitializeComponent();
            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            loginButton.Enabled = false;
            passwordBox.ReadOnly = true;
            usernameBox.ReadOnly = true;

            try
            {
                Client.MALLogin(username, password);
                ParentForm.DialogResult = DialogResult.OK;
                ParentForm.Close();
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
