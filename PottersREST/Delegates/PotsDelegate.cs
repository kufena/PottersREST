using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PottersBackEnd;

namespace PottersREST.Delegates
{
    public class PotsDelegate
    {

        IPotsAndPotters backEnd;

        public PotsDelegate(IPotsAndPotters ipap)
        {
            backEnd = ipap;
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

        private static string stringify_pot(Pots pot)
        {
            (var pid, var potterid, var pottername, var description) = pot;
            return "{" + pid + "," + potterid + "," + pottername + "," + description + "}";
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
        }
    }
}
