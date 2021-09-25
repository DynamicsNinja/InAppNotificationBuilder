using Microsoft.Xrm.Sdk;

namespace Fic.XTB.InAppNotificationBuilder.Proxy
{
    public class CustomPageProxy
    {
        public Entity Entity;
        public CustomPageProxy(Entity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            if (Entity != null)
            {
                return (string)Entity["displayname"];
            }

            return base.ToString();
        }
    }
}
