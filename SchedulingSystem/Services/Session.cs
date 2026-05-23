using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem.Services
{
    public static class Session
    {
        public static string CurrentUser { get; set; }
        public static int CurrentUserId { get; set; } 
    }
}
