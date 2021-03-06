﻿using System;
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
        private int _size = 32;
        private StatisticsPlayer stats;

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
        public int Size
        {
            get { return _size; }
            set { _size = value; OnPropertyChanged("Size"); }
        }
        public Brush ColorRect
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged("ColorRect"); }
        }
        public int Score
        {
            get { return stats.Score; }
            set { stats.Score = value; OnPropertyChanged("Score"); }
        }


        public EnemyPlayer(string login, Guid id)
        {
            _login = login;
            ID = id;
            ColorRect = GetRandomColor();

            stats = new StatisticsPlayer(_login);

        }
        public EnemyPlayer(string login, Guid id, int Size, int Score, Point position)
        {
            _login = login;
            stats = new StatisticsPlayer(_login);
            ID = id;
            this.Size = Size;
            stats.Score = Score;
            ColorRect = GetRandomColor();
            Position = position;

            
        }
        public void DeleteStats()
        {
            stats.Delete();
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
