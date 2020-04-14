using ClientWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using WcfService.Engine;

namespace ClientWPF.ViewModel
{
    class AppViewModel : ServiceReference1.IAuthorizationCallback, INotifyPropertyChanged
    {
        private ClientPlayer _player;
        private RelayCommand _authorization;
        private RelayCommand _registration;
        private RelayCommand _closing;
        private RelayCommand _moveRight;
        private RelayCommand _moveLeft;
        private RelayCommand _moveTop;
        private RelayCommand _moveDown;

        public AuthReg AuthReg;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<EnemyPlayer> EnemyPlayers { get; set; }
        public ObservableCollection<ClientPlayer> ClientPlayer { get; set; }


        private string _password;
        private string _login;
        private Visibility _visible;
        private bool _btnRegEnabled;
        private string _status;

        public RelayCommand Authorization
        {
            get
            {
                return _authorization ?? (_authorization = new RelayCommand(obj =>
                {
                    var id = AuthClient.client.Authorization(Login.ToLower(), Password);
                    if (id != Guid.Empty)
                    {
                        //Скрываем панель Авторизации
                        Visible = Visibility.Collapsed;
                        //Создаём игрока
                        _player = new Model.ClientPlayer(Login, id);
                        ClientPlayer.Add(_player);

                        //Получаем игроков с сервера для отображения
                        List<PlayerServer> EnemyList = AuthClient.client.GetAllPlayers(ClientPlayer[0].ID).ToList<PlayerServer>();
                        foreach (PlayerServer ServerPlayer in EnemyList)
                        {
                            EnemyPlayers.Add(new EnemyPlayer(ServerPlayer.Login, ServerPlayer.ID, ServerPlayer.Position));
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Неудачно");
                    }

                }));
            }
        }
        public RelayCommand Registration
        {
            get
            {
                return _registration ?? (_registration = new RelayCommand(obj =>
                {
                    var id = AuthClient.client.Registration(Login.ToLower(), Password);
                    if (id != Guid.Empty)
                    {
                        //Скрываем панель Авторизации
                        Visible = Visibility.Collapsed;
                        //Создаём игрока
                        _player = new Model.ClientPlayer(Login, id);
                        ClientPlayer.Add(_player);

                        //Получаем игроков с сервера для отображения
                        List<PlayerServer> EnemyList = AuthClient.client.GetAllPlayers(ClientPlayer[0].ID).ToList<PlayerServer>();
                        foreach (PlayerServer ServerPlayer in EnemyList)
                        {
                            EnemyPlayers.Add(new EnemyPlayer(ServerPlayer.Login, ServerPlayer.ID, ServerPlayer.Position));
                        }

                    }
                    else
                    {
                        MessageBox.Show("Неудачно");
                    }

                }));
            }
        }
        public RelayCommand Closing
        {
            get
            {
                return _closing ?? (_closing = new RelayCommand(obj =>
                {
                    if(ClientPlayer.Count > 0)
                        AuthClient.client.Disconnect(ClientPlayer[0].ID);
                }));
            }
        }
        public RelayCommand MoveRight
        {
            get 
            {
                return _moveRight ?? (_moveRight = new RelayCommand(obj =>
                {
                    Controls.MoveRight(ClientPlayer[0]);                   
                    AuthClient.client.ChangePosition(ClientPlayer[0].ID, ClientPlayer[0].Position);
                }));
            }
        }
        public RelayCommand MoveLeft
        {
            get
            {
                return _moveLeft ?? (_moveLeft = new RelayCommand(obj =>
                {
                    Controls.MoveLeft(ClientPlayer[0]);
                    AuthClient.client.ChangePosition(ClientPlayer[0].ID, ClientPlayer[0].Position);
                }));
            }
        }
        public RelayCommand MoveTop
        {
            get
            {
                return _moveTop ?? (_moveTop = new RelayCommand(obj =>
                {
                    Controls.MoveTop(ClientPlayer[0]);
                    AuthClient.client.ChangePosition(ClientPlayer[0].ID, ClientPlayer[0].Position);
                }));
            }
        }
        public RelayCommand MoveDown
        {
            get
            {
                return _moveDown ?? (_moveDown = new RelayCommand(obj =>
                {
                    Controls.MoveDown(ClientPlayer[0]);
                    AuthClient.client.ChangePosition(ClientPlayer[0].ID, ClientPlayer[0].Position);
                }));
            }
        }

        public AppViewModel()
        {
            AuthClient.client = new ServiceReference1.AuthorizationClient(new System.ServiceModel.InstanceContext(this));
            AuthClient.client.ServerStatus();
            ClientPlayer = new ObservableCollection<ClientPlayer>();
            EnemyPlayers = new ObservableCollection<EnemyPlayer>();
        }
        public string Login
        {
            get { return _login; }
            set 
            { 
                if(value[value.Length-1] != ' ')
                {
                    _login = value;
                    OnPropertyChanged("Login");
                    Ava();
                }
                 
            }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
        public string Status
        {
            get { return _status; }
            set {
                _status = value;
                OnPropertyChanged("Status");
                } 
        }
        public bool Enabled
        {
            get { return _btnRegEnabled; }
            set { _btnRegEnabled = value; OnPropertyChanged("Enabled"); }
        }
        public Visibility Visible
        {
            get { return _visible; }
            set { _visible = value; OnPropertyChanged("Visible"); }
        }
        public ClientPlayer Player
        {
            get { return _player; }

        }
       
        //Проверка на доступность логина
        public void Ava()
        {
            if(AuthReg.AvailabilityLogin(Login))
            {
                Status = "Ник не занят";
                Enabled = true;
            }
            else
            {
                Status = "Ник занят";
                Enabled = false;
            }
        }


        public void DisconectEnemy(Guid id)
        {
            var player = EnemyPlayers.FirstOrDefault(i => i.ID == id);
            EnemyPlayers.Remove(player);
        }

        public void ChangeEnemyPosition(Guid id, Point position)
        {
            var player = EnemyPlayers.FirstOrDefault(i => i.ID == id);
            if(player != null)
                player.Position = position;
        }

        public void ConnectEnemy(PlayerServer player)
        {
            EnemyPlayers.Add(new EnemyPlayer(player.Login, player.ID));
        }



        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        
    }
}
