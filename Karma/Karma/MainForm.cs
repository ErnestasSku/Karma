using System.Windows.Forms;

namespace Karma
{
    public partial class MainForm : Form
    {

        private Form CurrentForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (CurrentForm != null)
                CurrentForm.Close();
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

        private void MarketButton_Click(object sender, System.EventArgs e)
        {
            // TODO: move the logic somewhere else maybe for faster loads in the future when there will be a lot of items
            Form marketForm = new MarketForm();
            
            marketForm.TopLevel = false;
            marketForm.FormBorderStyle = FormBorderStyle.None;
            marketForm.Dock = DockStyle.Fill;
            this.Controls.Add(marketForm);
            marketForm.BringToFront();
            marketForm.Show();

            //Todo: refactor in the future.
            CurrentForm = marketForm;
        }
    }
}
