using System;
using System.Collections.Generic;
using System.Text;

namespace PottersBackEnd
{
    public interface IPotsAndPotters
    {
        int? createPotter(Potters potter);
        int? createPot(Pots pot);
        List<Potters> getAllPotters();
        Potters getPotterById(int id);
        List<Pots> getAllPots();
        List<Pots> getPotsByPotter(int id);
        Pots getPotById(int id);
    }
}
