using HtmlAgilityPack;
using ListaDeRadares.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ListaDeRadares.Services
{
    public class ParserService
    {
        private static AppSettings _appSettings;
        public List<Radar> Parse(AppSettings appSettings, string html)
        {
            _appSettings = appSettings;

            HtmlDocument _html = new HtmlDocument();
            _html.LoadHtml(html);

            List<Radar> radares = new List<Radar>();

            var stringRadares = _html.DocumentNode.SelectNodes(appSettings.Path);

            foreach (var radar in stringRadares.Skip(1))
            {
                var radarParseado = ParseRadar(radar);

                if(radarParseado != null)
                {
                    radares.Add(radarParseado);
                }
            }

            return radares;
        }

        private Radar ParseRadar(HtmlNode htmlRadar)
        {
            var radar = new Radar
            {
                Equipamento = htmlRadar.SelectSingleNode("td[1]").InnerHtml,
                Rodovia = htmlRadar.SelectSingleNode("td[2]").InnerHtml,
                Km = htmlRadar.SelectSingleNode("td[3]").InnerHtml,
                UF = htmlRadar.SelectSingleNode("td[4]").InnerHtml,
                Concessionaria = htmlRadar.SelectSingleNode("td[5]").InnerHtml
            };

            return radar.Equipamento.Equals("&nbsp;")? null : radar;
        }
    }
}
