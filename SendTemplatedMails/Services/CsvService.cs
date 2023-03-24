using CsvHelper;
using CsvHelper.Configuration;
using SendTemplatedMails.Models;
using System.Globalization;

namespace SendTemplatedMails.Services;

internal class CsvService
{
    public static IReadOnlyCollection<Input> GetInput(string file)
    {
        using var reader = new StreamReader(file);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
        using var csv = new CsvReader(reader, config);
        
        var inputs = csv.GetRecords<Input>();
            
        return inputs.ToList();
    }
}