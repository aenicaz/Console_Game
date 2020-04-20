using ClientWPF.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.ViewModel
{
    class StatisticsVM : BaseViewModel, INotifyPropertyChanged
    {
        private string _score;
        private string _countPlayer;

        public StatisticsVM():base(ConcreteMediator.getInstance())
        {

        }

        public override void Notify(object data)
        {
            
        }

        public string Score
        {
            get { return _score; }
            set { _score = value; OnPropertyChanged("Score"); }
        }
        public string CountPlayer
        {
            get { return _countPlayer; }
            set { _countPlayer = value; OnPropertyChanged("CountPlayer"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
