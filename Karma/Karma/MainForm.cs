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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm, object sender)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ContentPanel.Controls.Add(childForm);
            ContentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductNavigationButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormProduct(), sender);
        }

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewNavigationButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormAddNew(), sender);
        }

    }
}
