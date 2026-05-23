using MySqlConnector;
using SchedulingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static MySql.Data.MySqlClient.MySqlConnection;


namespace SchedulingSystem.Data
{
    public partial class AddressDataAccess
    {
        // ===== Helpers Methods =====
        public static int GetAddressId(string address)
        {
            string sql = @"SELECT addressId FROM address WHERE address = @address";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@address", MySqlDbType.VarChar, 50).Value = address;

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static bool AddressExists(AddressModel address, int addressId)
        {
            string sql = "SELECT COUNT(*) FROM address WHERE address = @address AND addressId = @addressId;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@address", MySqlDbType.VarChar, 50).Value = address;
            cmd.Parameters.Add("@addressId", MySqlDbType.VarChar, 50).Value = addressId;


            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        // ===== Add, Update & Delete Methods =====
        public static int AddAddress(
            MySqlConnector.MySqlConnection conn,
            MySqlConnector.MySqlTransaction tx,
            AddressModel address,
            int cityId,
            string username
       )
        {
            string sql = @"
                 INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy)
                 VALUES (@address, @address2, @cityId, @postalCode, @phone, NOW(), @createdBy, @lastUpdateBy);
                 SELECT LAST_INSERT_ID();";

            using (var cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@address", MySqlDbType.VarChar, 50).Value = address.Address;
                cmd.Parameters.Add("@address2", MySqlDbType.VarChar, 50).Value = address.Address2;
                cmd.Parameters.Add("@cityId", MySqlDbType.Int32).Value = cityId;
                cmd.Parameters.Add("@postalCode", MySqlDbType.VarChar, 10).Value = address.PostalCode;
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 20).Value = address.Phone;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 40).Value = username;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = username;

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static void UpdateAddress(
             MySqlConnector.MySqlConnection conn,
             MySqlConnector.MySqlTransaction tx,
             AddressModel address,
             int cityId,
             string username
        )
        {
            string sql = @"
                UPDATE address 
                SET
                    address = @address, 
                    address2 = @address2,
                    cityId = @cityId,
                    postalCode = @postalCode, 
                    phone = @phone, 
                    lastUpdateBy = @lastUpdateBy
                WHERE addressId = @addressId;";

            using var cmd = new MySqlCommand(sql, conn, tx);
            cmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = address.AddressId;
            cmd.Parameters.Add("@address", MySqlDbType.VarChar, 50).Value = address.Address;
            cmd.Parameters.Add("@address2", MySqlDbType.VarChar, 50).Value = address.Address2;
            cmd.Parameters.Add("@cityId", MySqlDbType.Int32).Value = cityId;
            cmd.Parameters.Add("@postalCode", MySqlDbType.VarChar, 10).Value = address.PostalCode;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 20).Value = address.Phone;
            cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = username;

            cmd.ExecuteNonQuery();
        }

        public static void DeleteAddress(MySqlConnection conn, MySqlTransaction tx,
            int addressId)
        {
            string sql = "DELETE FROM address WHERE addressId = @addressId";

            using (var cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("addressId", MySqlDbType.Int32).Value = addressId;
            }
        }

    }
}
