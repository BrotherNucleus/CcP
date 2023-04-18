using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class MainVindowViewModel : INotifyPropertyChanged
    {
        private int circleNumber;
        private int height = 700;
        private int width = 700;
        private string startButton;
        private static System.Timers.Timer timer;

        private ModelAPI modelApi { get; set; }

        public ObservableCollection<ICircleModel> circleModels
        {
            get => modelApi.CircleModels;
            set => modelApi.CircleModels = value;
        }

        public MainVindowViewModel()
        {
            modelApi = ModelAPI.CreateAPI();
            startButton = "start";
            startButtonClicked = new RelayCommand(()=>OnStartButtonClicked());
            circleNumber = 10;
            //timer = new System.Timers.Timer();
            //timer.Interval = 1000/30;
           // timer.Elapsed += UpdatePos;
            //timer.AutoReset = true;
            //timer.Enabled = true;
        }
        
        public ICommand startButtonClicked {get;set;}
        public string StartButton
        {
            get => startButton;
            set
            {
                startButton = value;
                DoesPropertyChanged("StartButton");

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

        //private void UpdatePos(Object source, System.Timers.ElapsedEventArgs e)
        //{
        //    modelApi.UpdatePosition();
        //}
        public void OnStartButtonClicked()
        {
                
                modelApi.Visualise(30, CircleNumber, width, height);
                StartButton = "working";
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void DoesPropertyChanged([CallerMemberName] string propertyName = null) 
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
