using System.Collections.Generic;
using System.ComponentModel;

namespace Fic.XTB.InAppNotificationBuilder.Model
{
    public class NotificationAction : INotifyPropertyChanged
    {
        public NotificationAction()
        {
            WebresourceParams = new Dictionary<string, string>();
        }

        [DisplayName("Type")]
        public ActionType ActionType { get; set; }
        [DisplayName("Text")]
        public string ActionText { get; set; }
        [Browsable(false)]
        public string Url { get; set; }
        [Browsable(false)]
        public string EntityName { get; set; }
        [Browsable(false)]
        public string FormId { get; set; }
        [Browsable(false)]
        public string ViewId { get; set; }
        [Browsable(false)]
        public string RecordId { get; set; }
        [Browsable(false)]
        public string CustomPageName { get; set; }
        [Browsable(false)]
        public string NavigationTarget { get; set; }
        [Browsable(false)]
        public string DashboardId { get; set; }
        [Browsable(false)]
        public string WebresourceName { get; set; }
        [Browsable(false)]
        public Dictionary<string,string> WebresourceParams { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
