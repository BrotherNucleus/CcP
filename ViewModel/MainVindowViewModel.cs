using System;
using System.Collections.ObjectModel;
using Model;

namespace ViewModel
{
    public class MainVindowViewModel
    {
        private int circleNumber;
        private int height = 350;
        private int width = 350;
        private string startButton;

        private ModelAPI modelApi { get; set; }

        public ObservableCollection<ICircleModel> circleModels = new ObservableCollection<ICircleModel>();

        public MainVindowViewModel()
        {
            modelApi = ModelAPI.CreateAPI();
        }

        public string StartButton
        {
            get => startButton;
            set
            {
                startButton = value;

            }
        }
        public int Height
        {
            get => height;
            set => height = value;
        }
        public int Width
        {
            get => width;
            set => width = value;
        }
        public int CircleNumber
        {
            get => circleNumber; set => circleNumber = value;
        }

        public void OnStartButtonClicked(Object sender, EventArgs e)
        {
            modelApi.Visualise(2, 2, width, height);
            circleModels = modelApi.CircleModels;
        }
    }
}
