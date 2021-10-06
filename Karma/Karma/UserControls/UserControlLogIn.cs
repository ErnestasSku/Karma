using System.Windows.Forms;

namespace Karma
{
    public partial class UserControlLogIn : UserControl
    {

        public UserControlLogIn()
        {
            InitializeComponent();
            textBox1.MaxLength = 20;
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 16;
        }
    }
}
