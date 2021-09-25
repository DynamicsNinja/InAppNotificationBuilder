using Microsoft.Xrm.Sdk;

namespace Fic.XTB.InAppNotificationBuilder.Proxy
{
    public class UserProxy
    {
        public Entity Entity;
        public UserProxy(Entity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            if (Entity != null)
            {
                return (string)Entity["fullname"];
            }

            return base.ToString();
        }
    }
}
