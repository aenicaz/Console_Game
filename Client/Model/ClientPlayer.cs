﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows;
using ClientWPF.Model.Events;

namespace ClientWPF.Model
{
    internal class ClientPlayer : INotifyPropertyChanged
    {
        private string _login;
        private Guid _id;
        private Point _position;
        private int _size;
        private Brush _color;
        private StatisticsPlayer stats;


        public event PropertyChangedEventHandler PropertyChanged;

        public string Login
        {
            get { return _login; }
        }
        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }
        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
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
        public int Score
        {
            get { return stats.Score; }
            set { stats.Score = value; OnPropertyChanged("Score");  }
        }

        public ClientPlayer(string login, Guid id)
        {
            Size = 32;
            _login = login;
            _id = id;
            ColorRect = GetRandomColor();
            stats = new StatisticsPlayer(_login);
            
            PlayerEvents.GetInstance().Eat += EatFood;

        }
        public ClientPlayer(string login, Guid id, Point position)
        {
            Size = 32;
            _login = login;
            _id = id;
            Position = position;
            ColorRect = GetRandomColor();
            stats = new StatisticsPlayer(_login);

            PlayerEvents.GetInstance().Eat += EatFood;
        }

        private void EatFood()
        {
            Size++;
            Score++;
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
