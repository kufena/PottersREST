﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
                vals[count] = JsonConvert.SerializeObject(potter);
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
                return JsonConvert.SerializeObject(potter);
            }
        }

        public int? CreatePotter(string s)
        {
            // format should be {<id>,<name>,<country>} but no id.
            // so just {<name>,<country>} ?

            Potters potter = parsePotter(s);
            int? newid = backEnd.createPotter(potter);
            return newid;
        }

        Potters parsePotter(string s)
        {
            return JsonConvert.DeserializeObject<Potters>(s);
        }
    }
}
