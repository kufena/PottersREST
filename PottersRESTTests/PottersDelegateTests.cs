using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using PottersBackEnd;
using PottersREST.Delegates;

namespace PottersRESTTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void no_potters_get_all_test()
        {
            var ipap = new Mock<IPotsAndPotters>();
            ipap.Setup(foo => foo.getAllPotters()).Returns(new List<Potters>());
            PottersDelegate pc = new PottersDelegate((IPotsAndPotters)ipap.Object);

            string[] outs = pc.GetAll();

            Assert.AreEqual(0, outs.Length);
            ipap.Verify(foo => foo.getAllPotters(), Times.AtMostOnce);
            ipap.VerifyNoOtherCalls();
        }

        [Test]
        public void one_potters_get_all_test()
        {
            var ipap = new Mock<IPotsAndPotters>();
            List<Potters> returned = new List<Potters>();
            Potters fitch = new Potters(1, "Fitch", "Scotland");
            returned.Add(fitch);

            ipap.Setup(foo => foo.getAllPotters()).Returns(returned);
            PottersDelegate pc = new PottersDelegate((IPotsAndPotters)ipap.Object);

            string[] outs = pc.GetAll();

            Assert.AreEqual(1, outs.Length);
            ipap.Verify(foo => foo.getAllPotters(), Times.AtMostOnce);
            ipap.VerifyNoOtherCalls();
        }

        [Test]
        public void three_potters_get_all_test()
        {
            var ipap = new Mock<IPotsAndPotters>();
            List<Potters> returned = makeThreePotters();

            ipap.Setup(foo => foo.getAllPotters()).Returns(returned);
            PottersDelegate pc = new PottersDelegate((IPotsAndPotters)ipap.Object);

            string[] outs = pc.GetAll();

            Assert.AreEqual(3, outs.Length);
            ipap.Verify(foo => foo.getAllPotters(), Times.AtMostOnce);
            ipap.VerifyNoOtherCalls();
        }

        [Test]
        public void get_by_id_test()
        {
            var ipap = new Mock<IPotsAndPotters>();
            ipap.Setup(foo => foo.getPotterById(1)).Returns(new Potters(1, "Fitch", "Scotland"));
            PottersDelegate pd = new PottersDelegate(ipap.Object);
            string s = pd.GetById(1);
            ipap.Verify(foo => foo.getPotterById(1), Times.AtMostOnce);
            ipap.VerifyNoOtherCalls();
        }

        [Test]
        public void create_potter_test()
        {
            var ipap = new Mock<IPotsAndPotters>();
            string s = "{\"Name\":\"Clive Bowen\",\"Country\":\"England\"}";
            Potters p = new Potters();
            p.Name = "Clive Bowen";
            p.Country = "England";
            ipap.Setup(foo => foo.createPotter(p)).Returns(4);

            PottersDelegate pd = new PottersDelegate(ipap.Object);
            int? newid = pd.CreatePotter(s);
            Assert.AreNotEqual(null, newid);
            Assert.AreEqual(4, newid);

            ipap.Verify(foo => foo.createPotter(p), Times.AtMostOnce);
            ipap.VerifyNoOtherCalls();

        }

        private static List<Potters> makeThreePotters()
        {
            List<Potters> returned = new List<Potters>();
            Potters fitch = new Potters(1, "Fitch", "Scotland");
            returned.Add(fitch);

            Potters blakely = new Potters(2, "Blakely", "England");
            Potters collins = new Potters(3, "Collins", "England");
            returned.Add(blakely);
            returned.Add(collins);
            return returned;
        }
    }
}