using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    //Статистика игры
    class StatisticsPlayer
    {
        private int _score;

        public void AddPoint()
        {
            _score++;
            
        }
    }
}
