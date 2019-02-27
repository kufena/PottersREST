using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottersBackEnd
{
    public class Potters
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public String Country { get; set; }

        public Potters()
        {
        }

        public Potters(int id, String name, String country) : this(name, country)
        {
            Id = id;
        }

        public Potters(String name, String country)
        {
            Name = name;
            Country = country;
        }

        public void Deconstruct(out int? id, out String name, out String country)
        {
            id = Id;
            name = Name;
            country = Country;
        }

        // I've overridden equals here to make the mock objects in the test work.
        public override bool Equals(object pot)
        {
            if (pot is Potters)
            {
                return Id == ((Potters) pot).Id;
            }
            return false;
        }
    }
}
