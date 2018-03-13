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
            var conn = new SqlConnection(CONNECTION_STRING);

            conn.Open();

            var cmd = conn.CreateCommand();
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

            conn.Close();
        }

        public bool Delete(SuperHero model)
        {
            throw new NotImplementedException();
        }

        public SuperHero Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<SuperHero> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(SuperHero model)
        {
            throw new NotImplementedException();
        }
    }
}
