using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PottersBackEnd;

namespace PottersREST.Delegates
{
    public class PottersDelegate
    {

        IPotsAndPotters backEnd;

        public PottersDelegate(IPotsAndPotters ipap)
        {
            backEnd = ipap;
        }

        public string[] GetAll()
        {
            var allpotters = backEnd.getAllPotters();
            string[] vals = new string[allpotters.Count];
            int count = 0;
            foreach (var potter in allpotters)
            {
                (var id, var name, var country) = potter;
                vals[count] = "{" + id + "," + name + "," + country + "}";
                count++;
            }
            return vals;
        }

        public string GetById(int v)
        {
            Potters potter = backEnd.getPotterById(v);
            if (potter == null)
                return null;
            else
            {
                (var id, var name, var country) = potter;
                return "{" + id + "," + name + "," + country + "}";
            }
        }

        public int? CreatePotter(string s)
        {
            // format should be {<id>,<name>,<country>} but no id.
            // so just {<name>,<country>} ?

            (var pname, var pcountry) = parsePotter(s);
            Potters potter = new Potters();
            potter.Name = pname;
            potter.Country = pcountry;

            int? newid = backEnd.createPotter(potter);
            return newid;
        }

        (string,string) parsePotter(string s)
        {
            // I think strictly speaking, this is incorrect.  To remove empty entries
            // ignores the fact I might have given "{fred,,,,,jimbo,,,}"
            var splits = s.Split(new char[] { '{', ',', '}' }, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length == 2)
                return (splits[0], splits[1]);
            return (null, null);
        }
        
    }
}
