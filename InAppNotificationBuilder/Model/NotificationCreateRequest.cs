namespace Fic.XTB.InAppNotificationBuilder.Model
{
    public class NotificationCreateRequest
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Ownerid { get; set; }
        public NotificationIcon Icontype { get; set; }
        public string Data { get; set; }
        public ToastType ToastType { get; set; }
    }
}
