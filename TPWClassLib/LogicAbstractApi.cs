using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWClassLib
{
    public abstract class LogicAbstractApi
    {
        public abstract void moveCircle(Circle circle, int x, int y);

        public abstract void moveAllCriclesRandomly(Scene scene);
        public abstract void stop(Scene scene);

        public static LogicAbstractApi CreateApi()
        {
            return new LogicApi();
        }
    }
}
