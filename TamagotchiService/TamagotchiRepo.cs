using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TamagotchiService.Models;

namespace TamagotchiService
{
    public class TamagotchiRepo : IRepository
    {
        Dictionary<string, Tamagotchi> tamagotchies = new Dictionary<string, Tamagotchi>();

        SqlConnection conn;
        SqlCommand cmd;

        public TamagotchiRepo()
        {
            conn = new SqlConnection("Server=tcp:testservermdaems.database.windows.net,1433;Initial Catalog=testDB;Persist Security Info=False;User ID=mdaems;Password=Rotterdam94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public Dictionary<string, Tamagotchi> GetAll()
        {
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Tamagotchi;";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Tamagotchi tamagotchi = new Tamagotchi(reader["Name"].ToString());
                tamagotchies.Add(reader["ID"].ToString(), tamagotchi);
            }
            conn.Close();

            return tamagotchies;
        }
    }
}