using System.IO;
using System.Net;
using ListaDeRadares.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace ListaDeRadares.Services
{
    public class ExtractionService
    {
        private static AppSettings _appSettings;
        public string Navigation(AppSettings appSettings)
        {
            _appSettings= appSettings;

            return GetPage();
        }

        public static string GetPage()
        {

        string html = string.Empty;
        string url = _appSettings.URL;

        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

        using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }
            return html;
        }
    }
}