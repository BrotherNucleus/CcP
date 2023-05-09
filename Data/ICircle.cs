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
        float X { get; }
        float Y { get; }
        float Radius { get; }

        float Cordinates { get; }

        void DoesPropertyChanged(string propertyName = null);
    }
}
