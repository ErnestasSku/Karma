using System;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Utils;
using System.Collections.Generic;

namespace Karma
{
    public partial class MarketForm : Form
    {


        public MarketForm()
        {
            InitializeComponent();
            string[] items = { "Name A-Z", "Name Z-A", "Oldest", "Newest" };
            comboBox1.Items.AddRange(items);
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedIndex;
            var descending = false;
            

            if (selected % 2 != 0)
                descending = true;

            ItemUtilities.SortItems(CSVProcessing.Items, ItemUtilities.GetSortType(selected), descending);
            this.InvokePaint(this, new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach(UserControlItem uc in ItemLayoutPanel.Controls.OfType<UserControlItem>())
            {
                if (!uc.TitleLabel.Text.ToLower().Contains(textBox1.Text.ToLower()) && 
                    !uc.DescriptionLabel.Text.ToLower().Contains(textBox1.Text.ToLower()) && 
                    !uc.item.Location.ToString().ToLower().Contains(textBox1.Text.ToLower()) &&
                    !uc.item.Category.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    uc.Visible = false;
                }
                else
                    uc.Visible = true;

            }    
        }
    }
}
