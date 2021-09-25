using Microsoft.Xrm.Sdk;

namespace Fic.XTB.InAppNotificationBuilder.Proxy
{
    public class WebresourceProxy
    {
        public Entity Entity;
        public WebresourceProxy(Entity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            if (Entity != null)
            {
                return Entity.Contains("displayname")
                    ? (string)Entity["displayname"] 
                    : (string)Entity["name"];
            }

            return base.ToString();
        }
    }
}
