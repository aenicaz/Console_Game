using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    class StatisticsGame: Statistics
    {
        private int _countPlayer;
        private List<string> _scorePlayer;

        public StatisticsGame()
        {
            AddGameStats(this);
        }
    }
}
