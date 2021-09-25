using System.ComponentModel;

namespace Fic.XTB.InAppNotificationBuilder.Model
{
    public class NotificationAction : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
