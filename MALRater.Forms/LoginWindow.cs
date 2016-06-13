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
        LoginUserControl loginUserControl = new LoginUserControl();

        public LoginWindow()
        {
            InitializeComponent();
            Controls.Add(loginUserControl);
            loginUserControl.Location = new Point(12, 12);
            ClientSize = new Size(
                 loginUserControl.Size.Width + loginUserControl.Location.X * 2,
                 loginUserControl.Size.Height + loginUserControl.Location.Y * 2);
        }
    }
}
