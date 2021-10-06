using System;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;

namespace Karma
{
    public partial class MarketForm : Form
    {

        public MarketForm()
        {
            InitializeComponent();
            //dataGridView1.DataSource = CSVProcessing.DataTableFromCSV();
            //prodLabel.Text = "There are " + CSVProcessing.Items.Length + " items in the market";
        }


        private void AddNewButtonClick(object sender, EventArgs e)
        {

            
            Form addNewItemForm = new AddNewItemForm();

            addNewItemForm.TopLevel = false;
            addNewItemForm.FormBorderStyle = FormBorderStyle.None;
            addNewItemForm.Dock = DockStyle.Fill;

            addNewItemForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
           
            this.Controls.Add(addNewItemForm);
            addNewItemForm.BringToFront();
            addNewItemForm.Show();
        }

        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {

            ItemLayoutPanel.Controls.Add(new UserControlItem(CSVProcessing.Items.Last()));
        }

        private void Button1Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = CSVProcessing.DataTableFromCSV();
            //prodLabel.Text = "There are " + CSVProcessing.Items.Length + " items in the market";
        }

        private void MarketForm_Paint(object sender, PaintEventArgs e)
        {
            ItemLayoutPanel.Controls.Clear();

            if (CSVProcessing.Items == null)
                return;
            foreach (var item in CSVProcessing.Items)
            {
                ItemLayoutPanel.Controls.Add(new UserControlItem(item));
            }

        }


    }
}
