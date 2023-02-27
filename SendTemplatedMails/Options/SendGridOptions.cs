namespace SendTemplatedMails.Options;

internal class SendGridOptions
{
    public static string key => "SendGrid";

    public string ApiKey { get; set; } = string.Empty;
    public string TemplateId { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
}