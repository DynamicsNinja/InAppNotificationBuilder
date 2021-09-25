using System.Windows.Forms;

namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    public partial class CodeForm : Form
    {
        public CodeForm(string code)
        {
            InitializeComponent();

            tbCode.Text = code;
        }
    }
}
