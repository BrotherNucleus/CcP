using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface  ICircleModel : INotifyPropertyChanged
    {
        float X { get; }
        float Y { get; }

        float Radius { get; }
        void DoesPropertyChanged(string propertyName = null);
    }
}
