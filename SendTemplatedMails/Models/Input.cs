using CsvHelper.Configuration.Attributes;

namespace SendTemplatedMails.Models;

internal class Input
{
    [Name("email")]
    public string Email { get; set; } = string.Empty;
}