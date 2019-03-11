using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PottersBackEnd;

namespace PottersREST.Delegates
{
    /*
     * This class exists to hold the data we want to go in our json object, but
     * without adulterating the original Pots class with stuff not related to it,
     * like URLs.  I'm not sure this is a great idea, but hey ho.
     */
    public class JSONPot
    {
        public JSONPot(Pots pot, IURLHelper urlhelper)
        {
            description = pot.Description;
            href = urlhelper.buildPotURL(pot.Id);
            potterhref = urlhelper.buildPotterURL(pot.PottersId);
        }
        public string href { get; set; }
        public string description { get; set; }
        public string potterhref { get; set; }
    }
}
