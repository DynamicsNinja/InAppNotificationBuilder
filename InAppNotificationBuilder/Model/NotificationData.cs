using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fic.XTB.InAppNotificationBuilder.Model
{
    public class NotificationData
    {
        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public List<NotificationActionJson> Actions { get; set; }
        [JsonProperty("iconUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl { get; set; }


        public NotificationData()
        {
            Actions = new List<NotificationActionJson>();
        }
    }

    public class NotificationActionJson
    {
        [JsonProperty("data")]
        public NotificationActionDataJson Data { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class NotificationActionDataJson
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("navigationTarget")]
        public string NavigationTarget { get; set; }
    }
}
