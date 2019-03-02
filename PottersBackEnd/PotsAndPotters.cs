using System;
using System.Collections.Generic;
using System.Text;

namespace PottersBackEnd
{
    public class PotsAndPotters : IPotsAndPotters
    {
        String connectionString;

        public PotsAndPotters(String s)
        {
            connectionString = s;
        }

        public int? createPot(Pots pot)
        {
            Potters potter = this.getPotterById(pot.PottersId);
            if (potter == null)
                return null;

            return (new PotsContext(connectionString)).createPot(pot);
        }

        public List<Pots> getAllPots()
        {
            return (new PotsContext(connectionString)).getAllPots();
        }

        public List<Pots> getPotsByPotter(int potterid)
        {
            return (new PotsContext(connectionString)).getPotsByPotter(potterid);
        }

        public int? createPotter(Potters potter)
        {
            return (new PottersContext(connectionString)).createPotter(potter);
        }

        public List<Potters> getAllPotters()
        {
            return (new PottersContext(connectionString)).getAllPotters();
        }

        public Potters getPotterById(int id)
        {
            return (new PottersContext(connectionString)).getPotterById(id);
        }

        public Pots getPotById(int id)
        {
            return (new PotsContext(connectionString)).getPotById(id);
        }
    }
}
