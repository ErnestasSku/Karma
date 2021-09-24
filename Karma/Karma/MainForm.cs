using System.Windows.Forms;

namespace Karma
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            userControlLogIn1.Hide();
            userControlRegister1.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userControlLogIn1.Show();
            userControlLogIn1.BringToFront();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userControlRegister1.Show();
            userControlRegister1.BringToFront();
        }

        private void userControlRegister1_Load(object sender, System.EventArgs e)
        {

        }
    }
}
