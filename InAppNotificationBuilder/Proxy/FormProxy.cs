using Microsoft.Xrm.Sdk;

namespace Fic.XTB.InAppNotificationBuilder.Proxy
{
    public class FormProxy
    {
        public Entity Entity;
        public FormProxy(Entity entity)
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