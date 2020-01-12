using Microsoft.Extensions.Configuration;
using System;

namespace TestConsole
{
    internal class Program
    {
        private static IConfiguration _configuration = null;

        private static void Main(string[] args)
        {
            var connectionString = "Pon aquí tu cadena de conexión";

            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(options =>
            {
                options.Connect(connectionString)
                    .ConfigureRefresh(refresh => //registramos el refresco
                    {
                        refresh.Register("asp:welcomesettings:author")
                                .Register("asp:welcomesettings:message")
                                .SetCacheExpiration(TimeSpan.FromSeconds(10));
                    });
            });
            _configuration = builder.Build();
            Console.WriteLine(_configuration["asp:welcomesettings:message"]);


            Console.ReadLine();
        }
    }
}
