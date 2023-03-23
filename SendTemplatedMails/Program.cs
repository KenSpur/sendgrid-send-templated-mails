using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendTemplatedMails.Models;
using SendTemplatedMails.Options;
using SendTemplatedMails.Services;

// Init Configuration
var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>().Build();

// Configure Services    
var services = new ServiceCollection();

services.AddTransient<IConfiguration>(_ => configuration);

services.AddOptions<SendGridOptions>().Configure<IConfiguration>(
    (options, config) => config.GetSection(SendGridOptions.key).Bind(options));

var serviceProvider = services.BuildServiceProvider();

// Get Options
var options = serviceProvider.GetService<IOptions<SendGridOptions>>()?.Value ?? new();

// Init Client
var client = new SendGridClient(options.ApiKey);

// Get emails
var inputs = CsvService.GetInput("input.csv");

// Send emails
var msg = MailHelper.CreateMultipleTemplateEmailsToMultipleRecipients(
    from: new EmailAddress(options.From),
    tos: inputs.Select(i => new EmailAddress(i.Email)).ToList(),
    templateId: options.TemplateId, 
    dynamicTemplateData: inputs.Select(i => new DynamicTemplateData
    {
        SubscribeUrl = new Uri($"{options.FunctionUrl}?code={options.FunctionAppKey}&email={i.Email}&firstname={i.Firstname}&lastname={i.Lastname}&type={options.TypeValue}").ToString()
    } as object).ToList());

Console.WriteLine($"Sending {inputs.Count} emails ...");
var response = await client.SendEmailAsync(msg);

Console.WriteLine($"Emails have been send. Response status code: {response.StatusCode}");
Console.WriteLine(await response.Body.ReadAsStringAsync());

// Done
Console.WriteLine("Press any key to exit...");

Console.ReadKey();