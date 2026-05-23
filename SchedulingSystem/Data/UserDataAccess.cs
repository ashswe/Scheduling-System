using Google.Protobuf.Compiler;
using MySqlConnector;
using Mysqlx.Crud;
using SchedulingSystem.Models;
using SchedulingSystem.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MySql.Data.MySqlClient.MySqlConnection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchedulingSystem.Data
{
    public static partial class UserDataAccess
    {
        // ===== Helpers Methods =====
        public static bool UsernameExists(string username)
        {
            string sql = "SELECT COUNT(*) FROM user WHERE username = @username;";

            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar, 50).Value = username;

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public static string GetPwdByUsername(string username)
        {
            string sql = "SELECT password FROM user WHERE username = @username;";

            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar, 50).Value = username;

                    return Convert.ToString(cmd.ExecuteScalar());
                }
            }
        }

        public static int GetUserId(string username)
        {
            string sql = @"SELECT userId FROM user WHERE username = @username;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 50).Value = username;

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            string sql = @"SELECT userId, userName FROM user;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var user = new UserModel();

                user.UserId = Convert.ToInt32(reader["userId"]);
                user.UserName = reader["userName"].ToString();

                users.Add(user);
            }

            return users;
        }

        // ===== Authenication & Register Methods =====
        public static bool AuthenticateUser(string username, string plainPassword)
        {
            string storedPassword = GetPwdByUsername(username);

            if (string.IsNullOrEmpty(storedPassword))
                return false;

            bool validUser;

            if (storedPassword.Contains(":"))
            {
                validUser = PasswordHasher.VerifyPassword(plainPassword, storedPassword);
            }
            else
            {
                validUser = plainPassword == storedPassword;
            }

            if (validUser)
            {
                Session.CurrentUser = username;
                Session.CurrentUserId = GetUserId(username);
            }

            return validUser;
        }

        public static bool RegisterUser(string username, string plainPassword)
        {
            if (UsernameExists(username))
            {
                return false;
            }

            string hashedPassword = PasswordHasher.HashPassword(plainPassword);

            string sql = @"
            INSERT INTO user (username, password, active, createdBy, lastUpdateBy)
            VALUES (@username, @password, @active, @createdBy, @lastUpdateBy);
            ";

            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar, 50).Value = username;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar, 50).Value = hashedPassword;
                    cmd.Parameters.Add("@active", MySqlDbType.Bit).Value = true;
                    //cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                    cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 40).Value = username;
                    cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = username;

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
        }
    }
}
