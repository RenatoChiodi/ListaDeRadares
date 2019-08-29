using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeRadares.Domain
{
    public class Radar
    {
        public string Equipamento { get; set; }
        public string Rodovia { get; set; }
        public string Km { get; set; }
        public string UF { get; set; }
        public string Concessionaria { get; set; }
    }
}
