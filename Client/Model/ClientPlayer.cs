using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows;

namespace ClientWPF.Model
{
    internal class ClientPlayer : INotifyPropertyChanged
    {
        private string _login;
        private Guid _id;
        private Point _position;
        private Brush _color;

        public event PropertyChangedEventHandler PropertyChanged;

        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }
        public Guid ID
        {
            get { return _id; }
        }
        public Brush ColorRect
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged("ColorRect"); }
        }

        public ClientPlayer(string login, Guid id)
        {
            _login = login;
            _id = id;
            ColorRect = GetRandomColor();
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
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    
    }
}
