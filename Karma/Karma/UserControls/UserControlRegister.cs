using System.Windows.Forms;

namespace Karma
{
    public partial class UserControlRegister : UserControl
    {
        public UserControlRegister()
        {
            InitializeComponent();
            textBox1.MaxLength = 20;
            textBox2.MaxLength = 20;
            textBox3.PasswordChar = '*';
            textBox3.MaxLength = 16;
            textBox4.PasswordChar = '*';
            textBox4.MaxLength = 16;
        }
    }
}
