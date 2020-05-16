using ClientWPF.Engine;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientWPF.ViewModel
{
    internal class StatisticsVM : BaseViewModel, INotifyPropertyChanged
    {
        private int _score;
        private int _countPlayer;



        public StatisticsVM() : base(ConcreteMediator.getInstance())
        {
            ConcreteMediator.getInstance().StatisticsVM = this;
        }

        public override void Notify(object data)
        {

        }

        public override void Send(object data)
        {
            //mediator 
            mediator.Send(data, this);
        }
       
        
        public int Score
        {
            get { return _score; }
            set { _score = value; OnPropertyChanged("Score"); }
        }
        public int CountPlayer
        {
            get { return _countPlayer; }
            set { _countPlayer = value; OnPropertyChanged("CountPlayer"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
