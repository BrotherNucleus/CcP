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
        public static ModelAPI CreateAPI(LogicAPI logic = default)
        {
            return new ModelLayer(logic ?? LogicAPI.CreateAPI());
        }
        public abstract void Visualise(int Radious, int CircleNumber, int width, int height);
        public abstract void UpdatePosition();
        public class ModelLayer : ModelAPI
        {
            private readonly LogicAPI logicAPI;

            public ModelLayer(LogicAPI logic)
            {
                logicAPI = logic;
            }
            public override void Visualise(int Radious, int CircleNumber, int width, int height)
            {
                logicAPI.createCircleList(CircleNumber, Radious, width, height);
                foreach (ICircle circle in logicAPI.GetCircles())
                {
                    circleModels.Add(new CircleModel(circle));

                }
                logicAPI.Start();

            }
            public override void UpdatePosition()
            {
                foreach (CircleModel circle in CircleModels)
                {
                    circle.Update();
                }
            }
        }
    }
}
