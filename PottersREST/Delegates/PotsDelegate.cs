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


    }
}
