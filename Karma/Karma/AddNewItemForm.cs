using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void uploadButton_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes =
            {
                nameTextBox, descriptionTextBox, contactInfoTextBox
            };
            saveToFile(textBoxes);
            this.Close();
        }
        private void saveToFile(TextBox[] textBoxes)
        {
            string text = ""; 
            foreach(TextBox textBox in textBoxes)
            {
                text += textBox.Text;
                text += ",";
            }
            text = text.Remove(text.Length - 1);
            CSVProcessing.AppendToCSV(text);
        }
        
        

    }
}
