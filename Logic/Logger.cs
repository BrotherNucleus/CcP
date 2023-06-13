using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class Logger
    {
        private static List<ICircleLogic> circles;
        private bool isLogging = true;
        private Timer timer;
        private int msInterval;

        public Logger(List<ICircleLogic> circleList)
        {
            circles = circleList;
            msInterval = 500;
            timer = new Timer(LogData, null, 0, msInterval);
        }

        public void LogData(object state)
        {
            StringWriter sw = new StringWriter();
            string time = $"{DateTime.Now:o}";
            foreach (ICircleLogic circle in circles)
            {
                sw.WriteLine(time + ";" + JsonSerializer.Serialize(circle));
            }

            using (StreamWriter file = new StreamWriter("log.txt", true))
            {
                file.WriteLine(sw.ToString());
            }
        }
    }
}
