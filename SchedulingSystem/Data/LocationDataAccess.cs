using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchedulingSystem.Data
{
    public class LocationDataAccess
    {
        // ===== Helpers Methods =====
        public static DataTable GetCountries()
        {
            DataTable table = new DataTable();

            string sql = "SELECT countryId, country FROM country ORDER BY country";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using (var cmd = new MySqlCommand(sql, conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(table);
            }

            return table;
        }

        public static DataTable GetCitiesByCountryId(int countryId)
        {
            DataTable table = new DataTable();

            string sql = "SELECT cityId, city FROM city WHERE countryId = @countryId ORDER BY city;";

            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@countryId", MySqlDbType.Int32).Value = countryId;

                using var adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }

            return table;
        }

        public static bool CityExists(string cityName, int countryId)
        {
            string sql = "SELECT COUNT(*) FROM city WHERE city = @city AND countryId = @countryId;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@city", MySqlDbType.VarChar, 50).Value = cityName;
            cmd.Parameters.Add("@countryId", MySqlDbType.Int32).Value = countryId;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public static bool CountryExists(string countryName)
        {
            string sql = "SELECT COUNT(*) FROM country WHERE country = @country;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@country", MySqlDbType.VarChar, 50).Value = countryName;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        // ===== Add City & Country =====
        public static int AddCity(string cityName, int countryId, string username)
        {
            string sql = @"
            INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@city, @countryId, NOW(), @username, NOW(), @username);
            SELECT LAST_INSERT_ID()
            ";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@city", MySqlDbType.VarChar, 50).Value = cityName;
            cmd.Parameters.Add("@countryId", MySqlDbType.Int32).Value = countryId;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 40).Value = username;

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static bool AddCountry(string countryName, string username)
        {
            if (CountryExists(countryName))
            {
                return false;
            }

            string sql = @"
            INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@country, NOW(), @username, NOW(), @username);
            ";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@country", MySqlDbType.VarChar, 50).Value = countryName;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 40).Value = username;

            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
