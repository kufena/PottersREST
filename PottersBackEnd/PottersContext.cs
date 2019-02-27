using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PottersBackEnd
{
    public class PottersContext
    {
        private String connectionString { get; set; }

        public PottersContext(string cs)
        {
            this.connectionString = cs;
        }

        public MySqlConnection getConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<Potters> getAllPotters()
        {
            List<Potters> list = new List<Potters>();
            using (MySqlConnection conn = getConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("select * from potters", conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Potters()
                        {
                            Id = Convert.ToInt32(reader.GetUInt32("Id")),
                            Name = reader.GetString("Name"),
                            Country = reader.GetString("Country")
                        });
                    }
                }
                conn.Close();
            }
            return list;
        }

        public Potters getPotterById(int id)
        {
            using (MySqlConnection conn = getConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("select Id, Name, Country from potters where Id= @Id", conn);
                command.Parameters.AddWithValue("@Id", id);
                
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (new Potters()
                        {
                            Id = Convert.ToInt32(reader.GetUInt32("Id")),
                            Name = reader.GetString("Name"),
                            Country = reader.GetString("Country")
                        });
                    }
                }
                conn.Close();
            }

            // if we get here we've not found a potter - not sure null is the right choice but
            // the UI shouldn't allow us to get here - although that's no guarantee.
            return null;
        }

        public int? createPotter(Potters potter)
        {
            (int? id, String name, String country) = potter;

            using (MySqlConnection conn = getConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into potters (Name, Country) values (?name, ?country)", conn);
                command.Parameters.AddWithValue("?name", name);
                command.Parameters.AddWithValue("?country", country);
                int affected = command.ExecuteNonQuery();
                if (affected == 1)
                    return (int) command.LastInsertedId;
                conn.Close();
            }

                return null;
        }
    }
}
