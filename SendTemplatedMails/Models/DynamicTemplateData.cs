using Newtonsoft.Json;

namespace SendTemplatedMails.Models;

public class DynamicTemplateData
{
    [JsonProperty("subscribe_url")] // SendGrid uses Newtonsoft.Json
    public string SubscribeUrl { get; set; } = string.Empty;
}