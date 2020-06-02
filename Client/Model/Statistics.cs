using ClientWPF.Model.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientWPF.Model
{
    class Statistics
    {
        public static ObservableCollection<StatisticsPlayer> _statisticsPlayers = new ObservableCollection<StatisticsPlayer>();
        private static StatisticsGame _statisticsGame;

        public Statistics()
        {
            PlayerEvents.GetInstance().Eat += SortPlayerStats;
            PlayerEvents.GetInstance().EnemyEat += SortPlayerStats;

           
        }

        protected void AddPlayerStats(StatisticsPlayer statistics)
        {
           _statisticsPlayers.Add(statistics);
        }
        
        protected void AddGameStats(StatisticsGame statistics)
        {
            _statisticsGame = statistics;
        }

        protected void DeleteStats(StatisticsPlayer stats)
        {
            _statisticsPlayers.Remove(stats);
        }
        
        public ObservableCollection<StatisticsPlayer> GetPlayerStatistics()
        {
            return _statisticsPlayers;
        }
        public StatisticsGame GetGameStatistics()
        {
            return _statisticsGame;
        }
        
        private protected void SortPlayerStats()
        {
            for(int i = 0; i < _statisticsPlayers.Count; i++)
                for(int j = _statisticsPlayers.Count - 1; j > i; j--)
                {
                    if(_statisticsPlayers[j-1].Score < _statisticsPlayers[j].Score)
                    {
                        var element = _statisticsPlayers[j - 1];
                        _statisticsPlayers[j - 1] = _statisticsPlayers[j];
                        _statisticsPlayers[j] = element;
                    }
                }
        }
       
    }
}
