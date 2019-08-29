using System;
using System.Collections.Generic;
using ListaDeRadares.Domain;
using ListaDeRadares.Services;

namespace ListaDeRadares
{
    class Program
    {
        
        static void Main(string[] args)
        {
            execute();
        }

       public static void execute()
       {
            ExtractionService extractionService = new ExtractionService();
            var html = extractionService.Navigation();

            ParserService parserService = new ParserService();
            var radares = parserService.Parse(html);

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
    }
}
