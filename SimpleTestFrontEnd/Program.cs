using System;
using System.Collections.Generic;

using PottersBackEnd;
using PottersREST.Delegates;

namespace SimpleTestFrontEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            IPotsAndPotters ipap = new PotsAndPotters("server=localhost;port=3306;database=simpleshopfrontdb;user=andrewd;password=3Ul3ripi-1.");

            var list = ipap.getAllPotters();
            Console.WriteLine("Number of potters found = " + list.Count);

            /* Potters potter = new Potters();
            potter.Name = "Ron Philbeck";
            potter.Country = "USA";

            int? newid = ipap.createPotter(potter);

            Console.WriteLine("new id is " + newid);
            */
            Potters potter = ipap.getPotterById(3);
            Console.WriteLine("Potter with id 3 is " + potter.Name);
            list = ipap.getAllPotters();
            Console.WriteLine("Number of potters found = " + list.Count);

            PottersDelegate pd = new PottersDelegate(ipap);
            int? newid = pd.CreatePotter("{Stephen Parry, England}");

            Console.WriteLine("New id is " + newid);

            PotsDelegate pod = new PotsDelegate(ipap);
            pod.createPot("{"+newid+",Stephen Parry, Ash glazed slender Jug}");

            /*
            Pots newpot = new Pots();
            if (potter.Id == null)
                Console.WriteLine("No potter id!");
            else
            {
                newpot.Potter = (int)potter.Id;
                newpot.PotterName = potter.Name;
                newpot.Description = "A 9 inch plate with a rabbit and flower motif, scraffito, slip ware.";
                int? mypotid = ipap.createPot(newpot);
                Console.WriteLine("my pot id is " + mypotid);
            }
            */
            
            List<Pots> allpots = ipap.getAllPots();
            List<Pots> ronpots = ipap.getPotsByPotter((int)potter.Id);

            Console.WriteLine("Hello World!");
        }
    }
}
