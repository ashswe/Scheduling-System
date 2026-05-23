using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem.Data
{
    public static class Database
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["SchedulingSoftwareDB"].ConnectionString;
    }
}
