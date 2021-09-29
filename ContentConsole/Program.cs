using ContentConsole.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ContentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var app = ActivatorUtilities.CreateInstance<AuthenticationHandler>(host.Services);

            app.HandleAuth();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
        {
            services.AddScoped<IApiClientService, ApiClientService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IBannedWordDictionary, BannedWordDictionary>();
            services.AddSingleton<IUserInputHandler, UserInputHandler>();
        });

    }
}
