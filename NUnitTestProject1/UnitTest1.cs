using NUnit.Framework;
using System;
using PottersBackEnd;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void deconstruct_pot()
        {
            Pots pot = new Pots();
            pot.PotterName = "Jimi";
            pot.Id = 22;
            pot.PottersId = 1;
            pot.Description = "Large Bowl";

            (int pot_id, int pot_potterid, String pot_pottername,String pot_description) = pot;
            Assert.AreEqual(22, pot_id);
            Assert.AreEqual(1, pot_potterid);
            Assert.AreEqual("Jimi", pot_pottername);
            Assert.AreEqual("Large Bowl", pot_description);
        }

        [Test]
        public void deconstruct_potter()
        {
            Potters potter = new Potters();
            potter.Id = 1;
            potter.Name = "Jimi";
            potter.Country = "USA";

            (int? potter_id, String potter_name, String potter_country) = potter;

            Assert.AreEqual(1, potter_id);
            Assert.AreEqual("Jimi", potter_name);

        }
    }
}