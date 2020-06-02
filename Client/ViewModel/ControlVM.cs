using ClientWPF.Engine;
using ClientWPF.Model;
using ClientWPF.Model.Events;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WcfService;

namespace ClientWPF.ViewModel
{
    internal class ControlVM : BaseViewModel, INotifyPropertyChanged
    {
        private Controls controls = new Controls();


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
                    controls.MoveRight();
                }));
            }
        }
        public RelayCommand MoveLeft
        {
            get
            {
                return _moveLeft ?? (_moveLeft = new RelayCommand(obj =>
                {
                    controls.MoveLeft();
                }));
            }
        }
        public RelayCommand MoveTop
        {
            get
            {
                return _moveTop ?? (_moveTop = new RelayCommand(obj =>
                {
                    controls.MoveTop();
                }));
            }
        }
        public RelayCommand MoveDown
        {
            get
            {
                return _moveDown ?? (_moveDown = new RelayCommand(obj =>
                {
                    controls.MoveDown();
                }));
            }
        }

        public ControlVM() : base(ConcreteMediator.getInstance())
        {
            ConcreteMediator.getInstance().ControlVM = this;
        }

        public override void Send(object data)
        {
            mediator.Send(data, this);
        }

        public override void Notify(object data)
        {
            if (data is ObservableCollection<FoodPoint>)
            {
                //_foodPoints = (ObservableCollection<FoodPoint>)data;
                controls.FoodPoints = (ObservableCollection<FoodPoint>)data;
                return;
            }
            if(data is ClientPlayer)
            {
                controls.Player = (ClientPlayer)data;
                return;
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
