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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
