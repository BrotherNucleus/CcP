using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICircle : INotifyPropertyChanged
    {
        int X { get; }
        int Y { get; }
        int Radius { get; }

        int Cordinates { get; }

        void DoesPropertyChanged(string propertyName = null);
    }
}
