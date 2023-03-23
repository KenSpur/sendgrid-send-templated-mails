using CsvHelper.Configuration.Attributes;

namespace SendTemplatedMails.Models;

internal class Input
{
    [Name("email")]
    public string Email { get; set; } = string.Empty;

    [Name("firstname")]
    public string Firstname { get; set; } = string.Empty;

    [Name("lastname")]
    public string Lastname { get; set; } = string.Empty;
}