using ClientWPF.Engine;
using ClientWPF.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientWPF.ViewModel
{
    internal class StatisticsVM : BaseViewModel, INotifyPropertyChanged
    {
        private Statistics _statistics;

        public ObservableCollection<StatisticsPlayer> ScorePlayer { get; set; }


        public StatisticsVM() : base(ConcreteMediator.getInstance())
        {
            ConcreteMediator.getInstance().StatisticsVM = this;

            _statistics = new Statistics();
            ScorePlayer = _statistics.GetPlayerStatistics();
        }

        #region Mediator
        public override void Notify(object data)
        {

        }
        public override void Send(object data)
        {
            //mediator 
            mediator.Send(data, this);
        }
        #endregion

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
