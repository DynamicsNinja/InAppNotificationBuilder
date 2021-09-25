using Microsoft.Xrm.Sdk;

namespace Fic.XTB.InAppNotificationBuilder.Proxy
{
    public class ViewProxy
    {
        public Entity Entity;
        public ViewProxy(Entity entity)
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