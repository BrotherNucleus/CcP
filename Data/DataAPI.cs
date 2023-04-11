using System;

namespace Data
{
    public abstract class DataAPI
    {
        public class DataLayer: DataAPI
        {
            public DataLayer() { }
        }
        public static DataAPI CreateAPI() 
        { 
            return new DataLayer();
        }
    }
}
