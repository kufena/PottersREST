using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PottersBackEnd;

namespace PottersREST.Delegates
{
    public class JSONPotter
    {
        public JSONPotter(Potters potter, IURLHelper urlhelper)
        {
            name = potter.Name;
            country = potter.Country;
            href = potter.Id == null ? "" : urlhelper.buildPotterURL((int)potter.Id);
            potshref = potter.Id == null ? "" : urlhelper.buildPotterURL((int)potter.Id) + @"/pots";

        }
        public string href { get; set; }
        public string potshref { get; set; }
        public string name { get; set; }
        public string country { get; set; }
    }
}
