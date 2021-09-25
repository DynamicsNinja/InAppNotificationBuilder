namespace Fic.XTB.InAppNotificationBuilder.Model
{
    public class NavigationTarget
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
