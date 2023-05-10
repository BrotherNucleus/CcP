using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICircleLogic : INotifyPropertyChanged
    {
        float X { get; }
        float Y { get; }
        float Radius { get; }
        float Ydir { get; }
        float Xdir { get; }
        bool IsCollision { get; set;}
        float Cordinates { get; }
        Vector2 Pos { get; }
        Vector2 Vel { get; }
        void DoesPropertyChanged(string propertyName = null);
    }
}
