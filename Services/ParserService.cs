using HtmlAgilityPack;
using ListaDeRadares.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ListaDeRadares.Services
{
    public class ParserService
    {
        public List<Radar> Parse(string _html)
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(_html);

            List<Radar> radares = new List<Radar>();

            var stringRadares = html.DocumentNode.SelectNodes("//div[@id='parent-fieldname-text-ad7b486622a84decaf3fbb6957ad7ff7']/table/tbody/tr");

            foreach (var radar in stringRadares.Skip(1))
            {
                radares.Add(ParseRadar(radar));
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

            return radar;
        }
    }
}
