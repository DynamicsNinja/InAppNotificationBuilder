using Microsoft.Xrm.Sdk;

namespace Fic.XTB.InAppNotificationBuilder.Proxy
{
    public class DashboardProxy
    {
        public Entity Entity;
        public DashboardProxy(Entity entity)
        {
            Entity = entity;
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
