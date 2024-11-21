using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker_Worksnaps
{
    internal static class Helper
    {
        public static long GetTimestamp(this DateTime value)
        {
            long epoch = (value.Ticks - 621355968000000000) / 10000000;
            return epoch;
        }

        public static DateTime ToLocalTime(this long timestamp)
        {
            DateTime startDatetime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return startDatetime.AddSeconds(timestamp).ToLocalTime();
        }

        public static DateTime RoundUpToNext10Minutes(this DateTime time)
        {
            return time.AddMinutes(
                time.Minute % 10 == 0
                    ? 0
                    : 10 - (time.Minute - ((time.Minute / 10) * 10))
            );
        }

        public static string AbsPath(this string path)
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/" + path;
        }
    }
}
