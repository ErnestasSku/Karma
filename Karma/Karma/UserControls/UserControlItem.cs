using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend;

namespace Karma
{
    public partial class UserControlItem : UserControl
    {
        public Item item;

        public UserControlItem(Item item)
        {
            InitializeComponent();
            this.item = item;
            TitleLabel.Text = item.Name;
            DescriptionLabel.Text = item.Description;
            try
            {
                PreviewImage.Image = Image.FromFile("TestImage.png");
            }
            catch
            {

            }
        }

    }
}
