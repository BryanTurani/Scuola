using CorsoEnaip2018_SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SuperHeroes.DataAccess
{
    public class SuperHeroSqlRepository : IRepository<SuperHero>
    {
        private const string CONNECTION_STRING = @"Data Source=TRISRV10\SQLEXPRESS; Initial Catalog=CorsoEuris_Bryan; Integrated Security=True";

        public void Insert(SuperHero model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText =
                        " INSERT INTO SuperHeroes" +
                        " ([Name], [SecretName], [Birth], [Strength], [CanFly], [KilledVillains])" +
                        " VALUES" +
                        " (@Name, @SecretName, @Birth, @Strength, @CanFly, @KilledVillains)";

                    // Quest'altra versione è equivalente:
                    // cmd.Parameters.Add(new SqlParameter("Name", model.Name));

                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@SecretName", model.SecretName);
                    cmd.Parameters.AddWithValue("@Birth", model.Birth);
                    cmd.Parameters.AddWithValue("@Strength", model.Strength);
                    cmd.Parameters.AddWithValue("@CanFly", model.CanFly);
                    cmd.Parameters.AddWithValue("@KilledVillains", model.KilledVillains);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<SuperHero> FindAll()
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SuperHeroes";

                    using (var reader = cmd.ExecuteReader())
                    {
                        var list = new List<SuperHero>();

                        while (reader.Read())
                        {
                            var sh = new SuperHero
                            {
                                Id = (int)reader[nameof(SuperHero.Id)],
                                Name = (string)reader[nameof(SuperHero.Name)],
                                SecretName = (string)reader[nameof(SuperHero.SecretName)],
                                Birth = (DateTime)reader[nameof(SuperHero.Birth)],
                                Strength = (int)reader[nameof(SuperHero.Strength)],
                                CanFly = (bool)reader[nameof(SuperHero.CanFly)],
                                KilledVillains = (int)reader[nameof(SuperHero.KilledVillains)]
                            };

                            list.Add(sh);
                        }

                        return list;
                    }
                }
            }
        }

        public SuperHero Find(int id)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SuperHeroes WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new SuperHero
                            {
                                Id = (int)reader[nameof(SuperHero.Id)],
                                Name = (string)reader[nameof(SuperHero.Name)],
                                SecretName = (string)reader[nameof(SuperHero.SecretName)],
                                Birth = (DateTime)reader[nameof(SuperHero.Birth)],
                                Strength = (int)reader[nameof(SuperHero.Strength)],
                                CanFly = (bool)reader[nameof(SuperHero.CanFly)],
                                KilledVillains = (int)reader[nameof(SuperHero.KilledVillains)]
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public bool Delete(SuperHero model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText =
                        "DELETE FROM SuperHeroes WHERE Id = @id";

                    cmd.Parameters.AddWithValue("Id", model.Id);

                    var result = cmd.ExecuteNonQuery();

                    return result == 1;
                }
            }
        }

        public bool Update(SuperHero model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText =
                        " UPDATE SuperHeroes SET" +
                        " [Name] = @name, " +
                        " [SecretName] = @secretname, " +
                        " [Birth] = @birth, " +
                        " [Strength] = @strength, " +
                        " [CanFly] = @canfly, " +
                        " [KilledVillains] = @killedvillains" +
                        " WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", model.Id);
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@secretname", model.SecretName);
                    cmd.Parameters.AddWithValue("@birth", model.Birth);
                    cmd.Parameters.AddWithValue("@strength", model.Strength);
                    cmd.Parameters.AddWithValue("@canfly", model.CanFly);
                    cmd.Parameters.AddWithValue("@killedvillains", model.KilledVillains);

                    var result = cmd.ExecuteNonQuery();

                    return result == 1;
                }
            }
        }
    }
}
