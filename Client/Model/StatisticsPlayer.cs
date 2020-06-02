using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClientWPF.Model.Events;

namespace ClientWPF.Model
{
    //Статистика игры
    class StatisticsPlayer : Statistics, INotifyPropertyChanged
    {
        private int _score = 0;
        private string _nick;
        public event PropertyChangedEventHandler PropertyChanged;



        public StatisticsPlayer(string Nick)
        {
            _nick = Nick;
            AddPlayerStats(this);
            SortPlayerStats();
        }

        //очки игрока
        public int Score
        {
            get { return _score; }
            set 
            { 
                _score = value;
                OnPropertyChanged("Score");
            }
        }

        public string Nick
        {
            get { return _nick; }
        }

        public void AddPoint()
        {
            Score++;
        }
        public void Delete()
        {
            DeleteStats(this);
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
