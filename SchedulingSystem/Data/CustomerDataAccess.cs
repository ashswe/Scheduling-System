using MySqlConnector;
using SchedulingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MySql.Data.MySqlClient.MySqlConnection;

namespace SchedulingSystem.Data
{
    public static partial class CustomerDataAccess
    {
        // ===== Helper Methods =====
        public static DataTable PopulateCustomerTable()
        {
            DataTable table = new DataTable();

            string sql = @"SELECT
                c.customerId,
                c.customerName,
                c.active,
                c.addressId,
                a.address,
                a.address2,
                a.postalCode,
                a.phone,
                ci.city,
                co.country
                FROM customer c
                JOIN address a ON c.addressId = a.addressId
                JOIN city ci ON a.cityId = ci.cityId
                JOIN country co ON ci.countryId = co.countryId;";

            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public static DataTable CustomerList()
        {
            DataTable customers = new DataTable();

            string sql = "SELECT customerName FROM customer ORDER BY customerName;";

            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using var cmd = new MySqlCommand(sql, conn);
                using var adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(customers);
            }

            return customers;
        }

        public static int GetCustomerId(string customerName)
        {
            string sql = @"SELECT customerId FROM customer WHERE customerName = @customer";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@customer", MySqlDbType.VarChar, 45).Value = customerName;

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static bool CustomerExists(int customerId)
        {
            string sql = @"SELECT COUNT(*) FROM customer WHERE customerId = @customerId";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;

            int count = Convert.ToInt32(cmd.ExecuteScalar());   
            return count > 0;
        }

        // ===== Add, Update, & Delete Methods =====
        public static void AddCustomer(
            MySqlConnection conn,
            MySqlTransaction tx,
            CustomerModel customer, 
            int addressId,
            string username
        )
        {
            string sql = @"
                INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                VALUES (@customerName, @addressId, @active, NOW(), @createdBy, NOW(), @lastUpdateBy);";

            using (var cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@customerName", MySqlDbType.VarChar, 45).Value = customer.CustomerName;
                //cmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = customer.AddressId;
                cmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = addressId;

                cmd.Parameters.Add("@active", MySqlDbType.Byte).Value = customer.Active ? 1 : 0;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 40).Value = username;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = username;

                cmd.ExecuteNonQuery();
            }
        }

        public static bool AddCustomerWithAddress(
            CustomerModel customer,
            AddressModel address,
            int cityId,
            string username
        )
        {
            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        int addressId = AddressDataAccess.AddAddress(conn, tx, address, cityId, username);

                        AddCustomer(conn, tx, customer, addressId, username);

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void UpdateCustomer(
            MySqlConnection conn,
            MySqlTransaction tx,
            CustomerModel customer,
            string username
        )
        {
            string sql = @"
                UPDATE customer 
                SET 
                    customerName = @customerName, 
                    active = @active, 
                    lastUpdate = NOW(), 
                    lastUpdateBy = @lastUpdateBy
                WHERE customerId = @customerId;";

            using (var cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@customerName", MySqlDbType.VarChar, 45).Value = customer.CustomerName;
                cmd.Parameters.Add("@active", MySqlDbType.Byte).Value = customer.Active ? 1 : 0;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = username;
                cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customer.CustomerId;

                cmd.ExecuteNonQuery();
            }
        }

        public static bool UpdateCustomerWithAddress(
            CustomerModel customer, 
            AddressModel address, 
            int cityId, 
            string username
        )
        {
            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        AddressDataAccess.UpdateAddress(conn, tx, address, cityId, username);

                        UpdateCustomer(conn, tx, customer, username);

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void DeleteCustomer(
            MySqlConnection conn,
            MySqlTransaction tx,
            int customerId)
        {
            string sql = "DELETE FROM customer WHERE customerId = @customerId";

            using (var cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;

                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteCustomerAddressAppointment(int customerId, int addressId)
        {
            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        AppointmentDataAccess.DeleteAppointmentWithCustomer(conn, tx, customerId);
                        DeleteCustomer(conn, tx, customerId);
                        AddressDataAccess.DeleteAddress(conn, tx, addressId);

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ===== Reports =====


    }
}
