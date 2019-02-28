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

    }
}
