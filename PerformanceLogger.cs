using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MetaphysicsIndustries.Utilities
{
    public static class PerformanceLogger
    {
        [Conditional("DEBUG")]
        public static void LogEvent(string message)
        {
            string s = string.Format("PerformanceLogger, {0,25}, {1,12}: {2}", DateTime.Now, Environment.TickCount, message);
            Debug.WriteLine(s);
        }
    }
}
