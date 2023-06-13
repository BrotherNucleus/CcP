using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICircleLogic : INotifyPropertyChanged
    {
        [JsonIgnore]
        float X { get; }
        [JsonIgnore]
        float Y { get; }
        [JsonIgnore]
        float Radius { get; }
        [JsonIgnore]
        float Ydir { get; }
        [JsonIgnore]
        float Xdir { get; }
        [JsonIgnore]
        bool IsCollision { get; set;}
        [JsonIgnore]
        float Cordinates { get; }
        [JsonIgnore]
        Vector2 Pos { get; }
        float PosX { get => Pos.X; }
        float PoxY { get => Pos.Y; }

        [JsonIgnore]
        Vector2 Vel { get; }
        void DoesPropertyChanged(string propertyName = null);
    }
}
