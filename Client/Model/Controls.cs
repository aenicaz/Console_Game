using ClientWPF.Model.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WcfService;

namespace ClientWPF.Model
{
    internal class Controls
    {
        private static PlayerEvents playerEvents = PlayerEvents.GetInstance();
        private static double speed = 4;

        private ObservableCollection<FoodPoint> _foodPoints;
        private ClientPlayer player;

        public ObservableCollection<FoodPoint> FoodPoints
        {
            set { _foodPoints = value; }
        }
        public ClientPlayer Player
        {
            set { player = value; }
        }

        public Controls()
        {
            PlayerEvents.GetInstance().ChangePos += EatFood;
        }



        public void MoveLeft()
        {
            if(player!=null)
            {
                Point pos = player.Position;
                pos.X -= speed;
                player.Position = pos;
                AuthClient.client.ChangePosition(player.ID, player.Position);
                playerEvents.Move();
            }
            
        }
        public void MoveRight()
        {
            if (player != null)
            {
                Point pos = player.Position;
                pos.X += speed;
                player.Position = pos;
                AuthClient.client.ChangePosition(player.ID, player.Position);
                playerEvents.Move();
            }
        }
        public void MoveTop()
        {
            if(player!= null)
            {
                Point pos = player.Position;
                pos.Y -= speed;
                player.Position = pos;
                AuthClient.client.ChangePosition(player.ID, player.Position);
                playerEvents.Move();
            }
        }
        public void MoveDown()
        {
            if(player != null)
            {
                Point pos = player.Position;
                pos.Y += speed;
                player.Position = pos;
                AuthClient.client.ChangePosition(player.ID, player.Position);
                playerEvents.Move();
            }
        }

        private void EatFood()
        {
            int number = 0;
            foreach (FoodPoint food in _foodPoints)
            {
                double l = Math.Sqrt(Math.Pow(food.Position.X + 5 - (player.Position.X + player.Size / 2), 2)
                    + Math.Pow(food.Position.Y + 5 - (player.Position.Y + player.Size / 2), 2));

                if (Math.Abs(l) < 5 + player.Size / 2) //5 = ширина/длина шара еды/2
                {
                    //вызов события, что клиент съел еду
                    PlayerEvents.GetInstance().EatFood();
                    number = food.ID;

                    Random r = new Random();
                    int x = r.Next(10, 550);
                    int y = r.Next(10, 350);

                    FoodPoint foodPoint = new FoodPoint(x, y, number);

                    _foodPoints.Remove(food);
                    _foodPoints.Add(foodPoint);

                    player.Size++;

                    AuthClient.client.EatFood(number, player.ID, foodPoint);
                    break;
                }
            }

        }


    }
}
