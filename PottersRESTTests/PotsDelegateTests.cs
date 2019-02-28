using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using PottersBackEnd;
using PottersREST.Delegates;

namespace PottersRESTTests
{
    class PotsDelegateTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void get_pot_by_id_test()
        {
            var mock = new Mock<IPotsAndPotters>();
            Pots p = new Pots(2, "Large Jug", 1, "Fitch");
            mock.Setup(foo => foo.getPotById(2)).Returns(p);

            var s = new PotsDelegate(mock.Object).getPotById(2);

            Assert.AreEqual("{2,1,Fitch,Large Jug}", s);
            mock.Verify(foo => foo.getPotById(2), Times.AtMostOnce);
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public void get_pots_by_potter()
        {
            var mock = new Mock<IPotsAndPotters>();
            Pots p1 = new Pots(2, "Large Jug", 1, "Fitch");
            Pots p2 = new Pots(3, "Large Bowl", 1, "Fitch");
            Pots p3 = new Pots(4, "Large Tankard", 1, "Fitch");
            List<Pots> allpots = new List<Pots>();
            allpots.Add(p1); allpots.Add(p2); allpots.Add(p3);
            mock.Setup(foo => foo.getPotsByPotter(1)).Returns(allpots);

            var strs = new PotsDelegate(mock.Object).getPotsByPotterId(1);
            Assert.AreEqual(3,strs.Length);
            mock.Verify(foo => foo.getPotsByPotter(1), Times.AtMostOnce);
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public void create_new_pot()
        {
            var mock = new Mock<IPotsAndPotters>();
            Pots p = new Pots("Large Jug", 1, "Fitch");
            mock.Setup(foo => foo.createPot(p)).Returns(1);

            int? newid = new PotsDelegate(mock.Object).createPot("{1,Fitch,Large Jug}");

            Assert.AreEqual(1,newid);
            mock.Verify(foo => foo.createPot(p), Times.AtMostOnce);
            mock.VerifyNoOtherCalls();
        }
    }
}
