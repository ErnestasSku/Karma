using System;
using System.Windows.Forms;
using BusinessLogic;

namespace Karma
{
    public partial class AddNewItemForm : Form
    {
       
        public AddNewItemForm()
        {
            InitializeComponent();
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
            SaveToFile(textBoxes);

            this.Close();
            
        }
        private void SaveToFile(TextBox[] textBoxes)
        {
            string text = "";
            foreach (TextBox textBox in textBoxes)
            {
                text += textBox.Text;
                text += ",";
            }
            DateTime time = DateTime.Now;
            text += time.ToString("u");

            CSVProcessing.AppendToCSV(text);
        }



    }
}
