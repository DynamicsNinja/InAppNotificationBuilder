using System.Windows.Forms;

namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    public partial class InsertImageForm : Form
    {
        private InAppNotificationBuilder _ianb;
        public InsertImageForm(InAppNotificationBuilder ianb)
        {
            _ianb = ianb;

            InitializeComponent();
        }

        private void btnInsert_Click(object sender, System.EventArgs e)
        {
            var altText = tbAltText.Text;
            var url = tbUrl.Text;

            _ianb.InsertImage(altText, url);

            Close();
        }
    }
}
