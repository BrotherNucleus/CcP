using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICircleLogic : INotifyPropertyChanged
    {
        int X { get; }
        int Y { get; }
        int Radius { get; }
        int Ydir { get; }
        int Xdir { get; }
        bool IsCollision { get; set;}
        int Cordinates { get; }
        void DoesPropertyChanged(string propertyName = null);
    }
}
