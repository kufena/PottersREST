using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PottersBackEnd
{
    public class PotsContext
    {
        private String connectionString { get; set; }

        public PotsContext(string cs)
        {
            this.connectionString = cs;
            
        }

        public MySqlConnection getConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<Pots> getAllPots()
        {
            List<Pots> list = new List<Pots>();
            using (MySqlConnection conn = getConnection())
            {
                conn.Open();
                
                MySqlCommand command = new MySqlCommand("select pots.Id as Id, potters.Id as PottersId, potters.Name as PotterName, pots.Description as Description from pots join potters where pots.pottersId = potters.Id and Live = 'T'", conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Pots()
                        {
                            Id = Convert.ToInt32(reader.GetUInt32("Id")),
                            Potter = Convert.ToInt32(reader.GetUInt32("PottersId")),
                            Description = reader.GetString("Description"),
                            PotterName = reader.GetString("PotterName")
                        });
                    }
                }
            }
            return list;
        }

        public List<Pots> getPotsByPotter(int potterId)
        {
            List<Pots> list = new List<Pots>();
            using (MySqlConnection conn = getConnection())
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand("select pots.Id as Id, potters.Id as PottersId, potters.Name as PotterName, " +
                    "pots.Description as Description from pots join potters " +
                    "where pots.pottersId = potters.Id and potters.Id=" + potterId + " and Live = '1'", conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Pots()
                        {
                            Id = Convert.ToInt32(reader.GetUInt32("Id")),
                            Potter = Convert.ToInt32(reader.GetUInt32("PottersId")),
                            Description = reader.GetString("Description"),
                            PotterName = reader.GetString("PotterName")
                        });
                    }
                }
            }
            return list;
        }

        public Pots getPotById(int potId)
        {
            using (MySqlConnection conn = getConnection())
            {
                conn.Open();

                try
                {
                    MySqlCommand command = new MySqlCommand("select pots.Id as Id, potters.Id as PottersId, potters.Name as PotterName, " +
                        "pots.Description as Description from pots join potters " +
                        "where pots.Id = ?potid and pots.potterId = potters.Id and Live = '1'", conn);
                    command.Parameters.AddWithValue("?potid", potId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Pots()
                            {
                                Id = Convert.ToInt32(reader.GetUInt32("Id")),
                                Potter = Convert.ToInt32(reader.GetUInt32("PottersId")),
                                Description = reader.GetString("Description"),
                                PotterName = reader.GetString("PotterName")
                            };
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }

            return null;
        }

        public int? createPot(Pots pot)
        {
            using (MySqlConnection conn = getConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into pots (PottersId, Name, Description) values (?pottersid, ?name, ?description)", conn);
                command.Parameters.AddWithValue("?pottersid", pot.Potter);
                command.Parameters.AddWithValue("?name", pot.PotterName);
                command.Parameters.AddWithValue("?description", pot.Description);
                int rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected == 1)
                    return (int) command.LastInsertedId;
            }

            return null;
        }
    }
}
