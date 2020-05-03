using ClientWPF.Engine;
using ClientWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WcfService;

namespace ClientWPF.ViewModel
{
    class ControlVM: BaseViewModel, INotifyPropertyChanged
    {
        public static ClientPlayer Player;
        private ObservableCollection<FoodPoint> _foodPoints;

        private RelayCommand _moveRight;
        private RelayCommand _moveLeft;
        private RelayCommand _moveTop;
        private RelayCommand _moveDown;

        public RelayCommand MoveRight
        {
            get
            {
                return _moveRight ?? (_moveRight = new RelayCommand(obj =>
                {
                    if (Player == null)
                        return;
                    Controls.MoveRight(Player);
                    AuthClient.client.ChangePosition(Player.ID, Player.Position);
                    EatFood(Player);

                }));
            }
        }
        public RelayCommand MoveLeft
        {
            get
            {
                return _moveLeft ?? (_moveLeft = new RelayCommand(obj =>
                {
                    Controls.MoveLeft(Player);
                    AuthClient.client.ChangePosition(Player.ID, Player.Position);
                    EatFood(Player);
                }));
            }
        }
        public RelayCommand MoveTop
        {
            get
            {
                return _moveTop ?? (_moveTop = new RelayCommand(obj =>
                {
                    Controls.MoveTop(Player);
                    AuthClient.client.ChangePosition(Player.ID, Player.Position);
                    EatFood(Player);
                }));
            }
        }
        public RelayCommand MoveDown
        {
            get
            {
                return _moveDown ?? (_moveDown = new RelayCommand(obj =>
                {
                    Controls.MoveDown(Player);
                    AuthClient.client.ChangePosition(Player.ID, Player.Position);
                    EatFood(Player);
                }));
            }
        }

        public ControlVM(): base(ConcreteMediator.getInstance())
        {
            ConcreteMediator.getInstance().ControlVM = this;
        }

        public override void Send(object data)
        {
            mediator.Send(data, this); 
        }

        public override void Notify(object data)
        {
            if(data is ObservableCollection<FoodPoint>)
            {
                _foodPoints = (ObservableCollection<FoodPoint>)data;
            }
        }

        private void EatFood(ClientPlayer player)
        {
            int number = 0;
            foreach(FoodPoint food in _foodPoints)
            {
                double l = Math.Sqrt(Math.Pow(food.Position.X+5 - (player.Position.X+player.Size/2), 2)
                    + Math.Pow(food.Position.Y+5 - (player.Position.Y+player.Size/2), 2));

                if (Math.Abs(l) < 21)
                {
                    number = food.ID;

                    Random r = new Random();
                    int x = r.Next(10, 550);
                    int y = r.Next(10, 350);

                    FoodPoint foodPoint = new FoodPoint(x, y, number);

                     _foodPoints.Remove(food);
                    //AppViewModel.FoodPoints.Remove(food);
                    _foodPoints.Add(foodPoint);
                    //AppViewModel.FoodPoints.Add(foodPoint);
                    
                    AuthClient.client.EatFood(number, player.ID, foodPoint);
                    break;
                }  
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
