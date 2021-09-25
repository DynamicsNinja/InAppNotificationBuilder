using Microsoft.Xrm.Sdk;

namespace Fic.XTB.InAppNotificationBuilder.Proxy
{
    public class AppProxy
    {
        public Entity Entity;
        public bool NotificationsEnabled;
        public AppProxy(Entity entity)
        {
            Entity = entity;
            NotificationsEnabled = false;
        }

        public override string ToString()
        {
            if (Entity != null)
            {
                return (string)Entity["name"];
            }

            return base.ToString();
        }
    }
}
