using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelAPI
    {
        private ObservableCollection<ICircleModel> circleModels = new ObservableCollection<ICircleModel>(); 

        public ObservableCollection<ICircleModel> CircleModels
        {
            get => circleModels;
            set => circleModels = value;
        }
        public class ModelLayer: ModelAPI
        {
            private readonly LogicAPI logicAPI;

            public ModelLayer(LogicAPI logic) 
            {
                logicAPI = logic;
            }
            public override void Visualise(int X, int Y, int Radious, int CircleNumber)
            {
                logicAPI.createCircleList(2, 2, 1, 1);
                foreach (Circle circle in logicAPI.Circles)
                {
                    circleModels.Add(new CircleModel(circle));

                }
                
            }
        }
        public static ModelAPI CreateAPI(LogicAPI logic = default) 
        {
            return new ModelLayer(logic ?? LogicAPI.CreateAPI());
        }
        public abstract void Visualise(int X, int Y, int Radious,int CircleNumber);

        
    }
}
