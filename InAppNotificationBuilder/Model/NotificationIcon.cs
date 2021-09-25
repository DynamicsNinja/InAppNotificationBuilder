namespace Fic.XTB.InAppNotificationBuilder.Model
{
    public class NotificationIcon
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
