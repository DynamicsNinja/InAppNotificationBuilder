using System.Windows.Forms;
using Fic.XTB.InAppNotificationBuilder.Proxy;

namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    public partial class SendTestNotificationForm : Form
    {
        private readonly InAppNotificationBuilder _inAppNotificationBuilder;

        public SendTestNotificationForm(InAppNotificationBuilder inAppNotificationBuilder)
        {
            _inAppNotificationBuilder = inAppNotificationBuilder;

            InitializeComponent();
            InitializeUserDropdown();
        }

        #region Events

        private void btnTest_Click(object sender, System.EventArgs e)
        {
            var selectedUser = ((UserProxy)cbUsers.SelectedItem).Entity;

            _inAppNotificationBuilder.SendTestNotification(selectedUser.Id);
        }

        #endregion

        #region Methods

        private void InitializeUserDropdown()
        {
            foreach (var user in _inAppNotificationBuilder.Users)
            {
                cbUsers.Items.Add(new UserProxy(user));
            }

            cbUsers.SelectedIndex = 0;
        }

        #endregion
    }
}
