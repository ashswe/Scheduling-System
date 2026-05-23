using Google.Protobuf.WellKnownTypes;
using MySqlConnector;
using Org.BouncyCastle.Tls;
using SchedulingSystem.Models;
using SchedulingSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MySql.Data.MySqlClient.MySqlConnection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchedulingSystem.Data
{
    public partial class AppointmentDataAccess
    {
        // ===== Helpers Methods =====
        public static DataTable PopulateAppointmentTable()
        {
            DataTable appointments = new DataTable();

            string sql = @"SELECT
                a.appointmentId,
                a.title,
                a.description,
                a.location,
                a.contact,
                a.type,
                a.url,
                a.start,
                a.end,
                c.customerId,
                u.userId
                FROM appointment a
                JOIN customer c ON a.customerId = c.customerId
                JOIN user u ON a.userId = u.userId;";

            using (var conn = new MySqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using var cmd = new MySqlCommand(sql, conn);
                using var adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(appointments);

                foreach (DataRow row in appointments.Rows)
                {
                    row["start"] = TimeHelper.UtcToLocal((DateTime)row["start"]);
                    row["end"] = TimeHelper.UtcToLocal((DateTime)row["end"]);
                }
            }

            return appointments;
        }

        public static DataTable PopulateDailyView(DateTime date)
        {
            var dailyView = new DataTable();

            DateTime dayStartLocal = date.Date;
            DateTime dayEndLocal = dayStartLocal.AddDays(1);

            DateTime dayStartUtc = TimeHelper.LocalToUtc(dayStartLocal);
            DateTime dayEndUtc = TimeHelper.LocalToUtc(dayEndLocal);

            string sql = @"
                SELECT
                    a.appointmentId,
                    a.title,
                    a.description,
                    a.location,
                    a.type,
                    a.start,
                    a.end,
                    a.customerId
                FROM appointment a
                WHERE a.start >= @dayStart
                  AND a.start <  @dayEnd
                ORDER BY a.start;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@dayStart", MySqlDbType.DateTime).Value = dayStartUtc;
            cmd.Parameters.Add("@dayEnd", MySqlDbType.DateTime).Value = dayEndUtc;

            using var adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dailyView);

            foreach (DataRow row in dailyView.Rows)
            {
                row["start"] = TimeHelper.UtcToLocal((DateTime)row["start"]);
                row["end"] = TimeHelper.UtcToLocal((DateTime)row["end"]);
            }

            return dailyView;
        }

        public static DataTable PopulateMonthlyView(DateTime date)
        {
            var monthlyView = new DataTable();

            DateTime monthStartLocal = new DateTime(date.Year, date.Month, 1);
            DateTime monthEndLocal = monthStartLocal.AddMonths(1);

            DateTime monthStartUtc = TimeHelper.LocalToUtc(monthStartLocal);
            DateTime monthEndUtc = TimeHelper.LocalToUtc(monthEndLocal);

            string sql = @"
                SELECT 
                    appointmentId, 
                    title, 
                    description, 
                    location, 
                    type, 
                    start, 
                    end, 
                    customerId
                FROM appointment
                WHERE start >= @start AND start < @end
                ORDER BY start;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = monthStartUtc;
            cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = monthEndUtc;

            using var adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(monthlyView);

            foreach (DataRow row in monthlyView.Rows)
            {
                row["start"] = TimeHelper.UtcToLocal((DateTime)row["start"]);
                row["end"] = TimeHelper.UtcToLocal((DateTime)row["end"]);
            }

            return monthlyView;
        }

        public static List<AppointmentModel> GetAllAppointments()
        {
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            string sql = @"SELECT userId, Title, Type, Start, End, Location FROM appointment;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            {
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var appointment = new AppointmentModel();

                    appointment.UserId = Convert.ToInt32(reader["userId"]);
                    appointment.Title = reader["title"].ToString();
                    appointment.Type = reader["type"].ToString();
                    appointment.Start = Convert.ToDateTime(reader["start"]);
                    appointment.End = Convert.ToDateTime(reader["end"]);
                    appointment.Location = reader["location"].ToString();

                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        public static bool AppointmentExists(int appointmentId)
        {
            string sql = @"
                SELECT COUNT(*) 
                FROM appointment 
                WHERE appointmentId = @appointmentId";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand( sql, conn);
            cmd.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public static bool AppointmentOverlaps(DateTime start, DateTime end, int? ignoreAppointmentId = null)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM appointment
                WHERE start < @end
                  AND end > @start
                  AND (@ignoreId IS NULL OR appointmentId <> @ignoreId);";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = end;
            cmd.Parameters.Add("@ignoreId", MySqlDbType.Int32).Value =
                ignoreAppointmentId.HasValue ? ignoreAppointmentId.Value : DBNull.Value;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public static DateTime? GetUpcomingAppointmentTime(int userId)
        {
            DateTime nowUtc = DateTime.UtcNow;
            DateTime in15MinutesUtc = nowUtc.AddMinutes(15);

            string sql = @"
                SELECT start
                FROM appointment
                WHERE userId = @userId
                  AND start >= @now
                  AND start <= @in15
                ORDER BY start
                LIMIT 1;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
            cmd.Parameters.Add("@now", MySqlDbType.DateTime).Value = nowUtc;
            cmd.Parameters.Add("@in15", MySqlDbType.DateTime).Value = in15MinutesUtc;

            object result = cmd.ExecuteScalar();

            return result == null || result == DBNull.Value ? null : Convert.ToDateTime(result);
        }

        // ===== Add, Update, & Delete Methods =====
        public static void AddAppointment(AppointmentModel appt, string username)
        {
            const string sql = @"
                INSERT INTO appointment(
                    customerId, 
                    userId, 
                    title, 
                    description,
                    location, 
                    contact, 
                    type, 
                    url, 
                    start, 
                    end,
                    createDate, 
                    createdBy, 
                    lastUpdate, 
                    lastUpdateBy)
                VALUES(
                    @customerId, 
                    @userId, 
                    @title, 
                    @description, 
                    @location, 
                    @contact, 
                    @type, 
                    @url, 
                    @start, 
                    @end,
                    NOW(), 
                    @username, 
                    NOW(), 
                    @username);";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = appt.CustomerId;
            cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = appt.UserId;

            cmd.Parameters.Add("@title", MySqlDbType.VarChar, 255).Value = appt.Title;
            cmd.Parameters.Add("@description", MySqlDbType.Text).Value = appt.Description;

            cmd.Parameters.Add("@location", MySqlDbType.Text).Value = appt.Location;
            cmd.Parameters.Add("@contact", MySqlDbType.Text).Value = appt.Contact;

            cmd.Parameters.Add("@type", MySqlDbType.Text).Value = appt.Type;
            cmd.Parameters.Add("@url", MySqlDbType.VarChar, 255).Value = appt.Url;

            cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = appt.Start;
            cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = appt.End;

            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 40).Value = username;

            cmd.ExecuteNonQuery();
        }

        public static void UpdateAppointment(AppointmentModel appt, string username)
        {
            string sql = @"
                UPDATE appointment 
                SET 
                    appointmentId = @appointmentId,
                    title = @title, 
                    description = @description, 
                    location = @location, 
                    contact = @contact, 
                    type = @type, 
                    url = @url, 
                    start = @start, 
                    end = @end,
                    lastUpdate = NOW(), 
                    lastUpdateBy = @username
                WHERE 
                    appointmentId = @appointmentId;";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appt.AppointmentId;
            cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = appt.UserId;

            cmd.Parameters.Add("@title", MySqlDbType.VarChar, 255).Value = appt.Title;
            cmd.Parameters.Add("@description", MySqlDbType.Text).Value = appt.Description;

            cmd.Parameters.Add("@location", MySqlDbType.Text).Value = appt.Location;
            cmd.Parameters.Add("@contact", MySqlDbType.Text).Value = appt.Contact;

            cmd.Parameters.Add("@type", MySqlDbType.Text).Value = appt.Type;
            cmd.Parameters.Add("@url", MySqlDbType.VarChar, 255).Value = appt.Url;

            cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = appt.Start;
            cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = appt.End;

            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 40).Value = username;

            cmd.ExecuteNonQuery();
        }

        public static void DeleteAppointment(int appointmentId)
        {
            string sql = "DELETE FROM appointment WHERE appointmentId = @appointmentId";

            using var conn = new MySqlConnection(Database.ConnectionString);
            conn.Open();

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;

            cmd.ExecuteNonQuery();
        }

        public static void DeleteAppointmentWithCustomer(
            MySqlConnection conn,
            MySqlTransaction tx,
            int customerId)
        {
            string sql = "DELETE FROM appointment WHERE customerId = @customerId";

            using (var cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
