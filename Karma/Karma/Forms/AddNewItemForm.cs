using System;
using System.Windows.Forms;
using Backend;

namespace Karma
{
    public partial class AddNewItemForm : Form
    {
       
        public AddNewItemForm()
        {
            InitializeComponent();
            categoryComboBox.DataSource = Enum.GetValues(typeof(Item.Categories));
            //Todo: by changing location, I break this thing. But there's no need to fix it 
            // As we will be switching to another UI framwork
            locationComboBox.DataSource = Enum.GetValues(typeof(Item.Categories));

        }

        /// <summary>
        /// Saves product data to the file.
        /// Todo: implement saveToFile() (Justas task, expand this method)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadButtonClick(object sender, EventArgs e)
        {
            TextBox[] textBoxes =
            {
                nameTextBox, descriptionTextBox, contactInfoTextBox
            };
            ComboBox[] comboBoxes =
            {
                categoryComboBox, locationComboBox
            };
            
            SaveToFile(textBoxes, comboBoxes);

            this.Close();
            
        }
        private void SaveToFile(TextBox[] textBoxes, ComboBox[] comboBoxes)
        {
            string text = "";
            foreach (TextBox textBox in textBoxes)
            {
                text += textBox.Text;
                text += ",";
            }
            foreach(ComboBox comboBox in comboBoxes)
            {
                text += comboBox.Text;
                text += ",";
            }

            DateTime time = DateTime.Now;
            text += time.ToString("u");

            CSVProcessing.AppendToCSV(text);
        }



    }
}
