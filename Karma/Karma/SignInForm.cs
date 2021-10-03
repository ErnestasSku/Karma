using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karma
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControlLogIn1.Show();
            userControlLogIn1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControlRegister1.Show();
            userControlRegister1.BringToFront();
        }
    }
}
