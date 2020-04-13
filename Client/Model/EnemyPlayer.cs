using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ClientWPF.Model
{
    class EnemyPlayer: INotifyPropertyChanged
    {
        private string _login;
        private Point _position;
        private Brush _color;

        public event PropertyChangedEventHandler PropertyChanged;

        public Guid ID { get; private set;}
        public Point Position
        {
            get { return _position; }
            set { _position = value;  OnPropertyChanged("Position");  }
        }
        public string Login
        {
            get { return _login; }
        }
        public Brush ColorRect
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged("ColorRect"); }
        }

        public EnemyPlayer(string login, Guid id)
        {
            _login = login;
            ID = id;
            ColorRect = GetRandomColor();

        }
        public EnemyPlayer(string login, Guid id, Point position)
        {
            _login = login;
            ID = id;
            ColorRect = GetRandomColor();
            Position = position;
        }

        private Brush GetRandomColor()
        {
            Random r = new Random();
            SolidColorBrush solidColorBrush = new SolidColorBrush();
            solidColorBrush.Color = Color.FromRgb((Byte)r.Next(0, 255), (Byte)r.Next(0, 255), (Byte)r.Next(0, 255));
            return solidColorBrush;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
