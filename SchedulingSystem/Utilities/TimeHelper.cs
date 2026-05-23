using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem.Utilities
{
    public static class TimeHelper
    {
        public static DateTime LocalToUtc(DateTime local)
        {
            var dto = new DateTimeOffset(local, TimeZoneInfo.Local.GetUtcOffset(local));
            return dto.UtcDateTime;
        }

        public static DateTime UtcToLocal(DateTime utc)
        {
            var utcKind = DateTime.SpecifyKind(utc, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(utcKind, TimeZoneInfo.Local);
        }
    }
}
