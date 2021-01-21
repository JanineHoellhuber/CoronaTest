using CoronaTest.Core.Contracts;
using CoronaTest.Core.Service;
using Microsoft.Extensions.Configuration;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CoronaTestPoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<TwilioSmsService>()
                .AddEnvironmentVariables()
                .Build();

            ISmsService smsService = new TwilioSmsService(configuration["Twillio:AccountSid"] , configuration["Twillio:AuthToken"]);

            string to = "+4367761289711";
            string message = "Hello World from Twilio SMS service.";


            smsService.SendSms(to, message);
        }
    }
}
