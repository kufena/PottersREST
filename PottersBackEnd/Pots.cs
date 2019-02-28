using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottersBackEnd
{
    public class Pots
    {
        public int Id { get; set; }
        public int Potter { get; set; }
        public String Description { get; set; }
        public String PotterName { get; set; }

        public Pots()
        {

        }

        public Pots(int id, string desc, int potterid, string pottername) : this(desc, potterid, pottername)
        {
            Id = id;
        }

        public Pots(string desc, int potterid, string pottername)
        {
            Description = desc;
            Potter = potterid;
            PotterName = pottername;
        }

        public void Deconstruct(out int id, out int potter, out string pottername, out string description)
        {
            id = Id;
            potter = Potter;
            pottername = PotterName;
            description = Description;
        }

        // I've overridden equals here to make the mock objects in the test work.
        public override bool Equals(object pot)
        {
            if (pot is Pots)
            {
                return Id == ((Potters)pot).Id;
            }
            return false;
        }
    }
}
