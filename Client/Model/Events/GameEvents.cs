using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model.Events
{
    class GameEvents
    {
        private static GameEvents instance;
        public delegate void GameHandler();

        public event GameHandler Connect;
        public event GameHandler Disconnect;


        //Вызов события измение позиции
        public void PlayerConnect()
        {
            Connect?.Invoke();
        }

        public void PlayerDisconnect()
        {
            Disconnect?.Invoke();
        }

        public static GameEvents GetInstance()
        {
            if (instance != null)
                return instance;
            else
                return instance = new GameEvents();
        }
    }
}
