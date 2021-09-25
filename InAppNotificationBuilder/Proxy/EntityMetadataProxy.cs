using System.Linq;
using Microsoft.Xrm.Sdk.Metadata;

namespace Fic.XTB.InAppNotificationBuilder.Proxy
{
    public class EntityMetadataProxy
    {
        public EntityMetadata Entity;
        public EntityMetadataProxy(EntityMetadata entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            return $"{Entity.DisplayName.LocalizedLabels.FirstOrDefault()?.Label ?? Entity.LogicalName} ({Entity.LogicalName})";
        }
    }
}