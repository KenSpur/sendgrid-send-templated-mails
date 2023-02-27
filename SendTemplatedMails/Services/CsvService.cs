using CsvHelper;
using SendTemplatedMails.Models;
using System.Globalization;

namespace SendTemplatedMails.Services
{
    internal class CsvService
    {
        public static IReadOnlyCollection<Input> GetInput(string file)
        {
            using var reader = new StreamReader(file);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            var inputs = csv.GetRecords<Input>();
                
            return inputs.ToList();
        }
    }
}