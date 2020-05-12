using System;
using System.Collections.Generic;
using ListaDeRadares.Domain;
using ListaDeRadares.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ListaDeRadares
{
    class Program
    {
        private static AppSettings _appSettings;
        static void Main(string[] args)
        {
            Config();
            execute();
        }

       public static void execute()
       {
            ExtractionService extractionService = new ExtractionService();
            var html = extractionService.Navigation(_appSettings);

            ParserService parserService = new ParserService();
            var radares = parserService.Parse(_appSettings, html);

            printRadares(radares);
       }

        private static void printRadares(List<Radar> radares)
        {
            Console.WriteLine(" ____________________________________________________________");
           foreach(var radar in radares)
            {
                Console.WriteLine($"|{radar.Equipamento} \t|{radar.Rodovia} \t|{radar.Km} \t|" +
                                    $"{radar.UF} \t|{radar.Concessionaria}|");

                Console.WriteLine(" ____________________________________________________________");
            }
            Console.ReadKey();
        }

        private static void Config()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("config.json")
                .Build();

            var appSettingsSection = configuration.GetSection("AppSettings");

            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<AppSettings>(appSettingsSection)
                .BuildServiceProvider();

            _appSettings = new AppSettings();
            appSettingsSection.Bind(_appSettings);
        }
    }
}
