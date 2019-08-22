using System;
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
        ExtractionService.Navigation();

        }
    }
}
