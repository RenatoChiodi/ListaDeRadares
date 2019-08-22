using System;
using System.Net;
using System.IO;

namespace ListaDeRadares.Services
{
    public class ExtractionService
    {
        public static void Navigation()
        {
            GetPage();
        }

        public static void GetPage()
        
        {
        string html = string.Empty;
        string url = "https://www.prf.gov.br/portal/multas-e-infracoes/lista-de-radares-fixos";

        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

        using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }
            Console.WriteLine(html);
        }
    }
}