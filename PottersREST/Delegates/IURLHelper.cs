using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottersREST.Delegates
{
    public interface IURLHelper
    {
        string buildPotURL(int id);
        string buildPotterURL(int id);
    }
}
