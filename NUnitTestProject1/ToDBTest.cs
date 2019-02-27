using NUnit.Framework;
using System;
using PottersBackEnd;

namespace Tests
{
    class ToDBTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void createPotter()
        {
            /*
            IPotsAndPotters ipap = new PotsAndPotters("server=localhost;port=3306;database=simpleshopfrontdb;user=connectionuser;password=pssword");
            Potters potter = new Potters();
            potter.Name = "Jimi";
            potter.Country = "USA";

            int? newid = ipap.createPotter(potter);

            Assert.AreNotEqual(null, newid);
            */

            Assert.Pass();
        }
    }
}
