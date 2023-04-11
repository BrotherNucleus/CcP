using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface  ICircleModel
    {
        int X { get; }
        int Y { get; }

        int Radius { get; }
        void DoesPropertyChanged(string propertyName = null);
    }
}
