using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model.Events
{
    class PlayerEvents
    {
        private static PlayerEvents instance;
        public delegate void PlayerHandler();

        public event PlayerHandler ChangePos;
        public event PlayerHandler Eat;
        public event PlayerHandler EnemyEat;
        

        //Вызов события измение позиции
        public void Move()
        {
            ChangePos?.Invoke();
        }
        public void EatFood()
        {
            Eat?.Invoke();
        }
        public void EnemyEatFood()
        {
            EnemyEat?.Invoke();
        }

        public static PlayerEvents GetInstance()
        {
            if (instance != null)
                return instance;
            else
                return instance = new PlayerEvents();
        }
    }
}
