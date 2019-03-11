using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PottersBackEnd;

namespace PottersREST.Delegates
{
    public class PotsDelegate
    {

        IPotsAndPotters backEnd;
        IURLHelper urlhelper;

        public PotsDelegate(IPotsAndPotters ipap, IURLHelper urlhelper)
        {
            backEnd = ipap;
            this.urlhelper = urlhelper;
        }

        public string getPotById(int id)
        {
            Pots pot = backEnd.getPotById(id);
            if (pot == null)
                return null;
            else
            {                
                return stringify_pot(pot);
            }
        }
        
        public string[] getPotsByPotterId(int pid)
        {
            var list = backEnd.getPotsByPotter(pid);
            string[] results = new string[list.Count];
            int count = 0;
            foreach(var pot in list)
            {
                results[count] = stringify_pot(pot);
                count++;
            }
            return results;
        }

        private string stringify_pot(Pots pot)
        {
            JSONPot jsonpot = new JSONPot(pot, urlhelper);
            string s = JsonConvert.SerializeObject(jsonpot);

            return s;
        }

        public int? createPot(string v)
        {
            Pots p = parsePot(v);
            if (p == null)
                return null;
            return backEnd.createPot(p);
        }

        private Pots parsePot(string v)
        {
            Pots p = JsonConvert.DeserializeObject<Pots>(v);
            return p;
            /*
            string[] splits = v.Split(new char[] { ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length == 3)
            {
                int potterid;
                if (int.TryParse(splits[0], out potterid))
                {
                    return new Pots(splits[2], potterid, splits[1]);
                }
            }
            return null;
            */
        }
    }
}
