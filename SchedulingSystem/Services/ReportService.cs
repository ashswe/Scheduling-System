using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Tls;
using SchedulingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem.Services
{
    public class ReportService
    {
        // ===== Fields =====
        private readonly List<AppointmentModel> _appointments;
        private readonly List<UserModel> _users;

        // ===== Constructor =====
        public ReportService(List<AppointmentModel> appointments, List<UserModel> users)
        {
            _appointments = appointments ?? new();
            _users = users ?? new();
        }

        // ===== Helper Methods =====
        private static DataTable ToDataTable<T>(IList<T> items)
        {
            var table = new DataTable();

            if (items == null || items.Count == 0) return table;

            // Fill columns
            var properties = typeof(T).GetProperties();

            foreach (var p in properties)
            {
                table.Columns.Add(p.Name);
            }

            // Fill rows
            foreach (var item in items)
            {
                var row = table.NewRow();

                foreach (var p in properties)
                {
                    row[p.Name] = p.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GetReport(string reportName)
        {
            return reportName switch
            {
                "Appointment Types by Month" => AppointmentTypesByMonth(),
                "Schedule for Each User" => ScheduleForEachUser(),
                "Appointments by Location" => AppointmentsByLocation(),
                _ => new DataTable()
            };
        }

        // ===== Report DataTables =====
        private DataTable AppointmentTypesByMonth()
        {
            var rows = _appointments
                .GroupBy(a => new { Month = new DateTime(a.Start.Year, a.Start.Month, 1), a.Type })
                .Select(g => new
                {
                    Month = g.Key.Month.ToString("yyyy-MM"),
                    Type = g.Key.Type,
                    Count = g.Count()
                })
                .OrderBy(r => r.Month)
                .ThenBy(r => r.Type)
                .ToList();

            return ToDataTable(rows);
        }

        private DataTable ScheduleForEachUser()
        {
            var rows = _appointments
                .Join(
                    _users,
                    a => a.UserId,
                    u => u.UserId,
                    (a, u) => new
                    {
                        User = u.UserName,
                        a.Title,
                        a.Type,
                        Start = a.Start,
                        End = a.End,
                        a.Location
                    })
                .OrderBy(r => r.User)
                .ThenBy(r => r.Start)
                .ToList();

            return ToDataTable(rows);
        }

        private DataTable AppointmentsByLocation()
        {
            var rows = _appointments
                .GroupBy(a => string.IsNullOrWhiteSpace(a.Location) ? "(No Location)" : a.Location.Trim())
                .Select(g => new
                {
                    Location = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(r => r.Count)
                .ThenBy(r => r.Location)
                .ToList();

            return ToDataTable(rows);
        }
    }
}
