using Fic.XTB.InAppNotificationBuilder.Model;
using System.Windows.Forms;

namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    public partial class PowerAutomateForm : Form
    {
        public PowerAutomateForm(NotificationCreateRequest req)
        {
            InitializeComponent();

            tbTitle.Text = req.Title;
            tbBody.Text = req.Body;
            tbData.Text = req.Data;
            tbIconType.Text = req.Icontype.Name;
            tbOwner.Text = $@"systemusers({req.Ownerid})";
        }
    }
}
