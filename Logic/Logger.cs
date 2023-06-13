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
        private Stopwatch stopwatch;
        private bool isLogging = true;

        public Logger(List<ICircleLogic> circleList) {
            
            circles = circleList;
            Thread thread = new Thread(() => StartLogging(100));
            thread.IsBackground = true;
            thread.Start();
        }

        public void StartLogging(int msInterwal) 
        {
            stopwatch = Stopwatch.StartNew();

            while(isLogging)
            {
                if (stopwatch.ElapsedMilliseconds < msInterwal)
                {
                    StringWriter sw = new StringWriter();
                    stopwatch.Restart();
                    string time = ($"{DateTime.Now:o}");
                    foreach (ICircleLogic circle in circles)
                    {
                        sw.WriteLine(time + ";"+ JsonSerializer.Serialize(circle));

                    }
                    using (StreamWriter file = new StreamWriter("log.txt",true))
                    {
                        file.WriteLine(sw.ToString());
                    }
                }
            }
        }
    }
}
