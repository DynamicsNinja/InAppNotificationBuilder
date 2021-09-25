using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata.Query;

namespace Fic.XTB.InAppNotificationBuilder.Helper
{
    public static class MetadataHelper
    {
         public static string[] EntityProperties = { "LogicalName", "DisplayName", "ObjectTypeCode", "IsManaged", "IsCustomizable", "IsCustomEntity", "IsIntersect", "IsValidForAdvancedFind" };

        public static RetrieveMetadataChangesResponse LoadEntities(IOrganizationService service)
        {
            if (service == null) { return null; }

            var eqe = new EntityQueryExpression {Properties = new MetadataPropertiesExpression(EntityProperties)};

            var req = new RetrieveMetadataChangesRequest
            {
                Query = eqe,
                ClientVersionStamp = null
            };

            return service.Execute(req) as RetrieveMetadataChangesResponse;
        }
    }
}