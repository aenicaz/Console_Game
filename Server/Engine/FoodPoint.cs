using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;


namespace WcfService
{
    [DataContract]
    public class FoodPoint
    {
        [DataMember]
        private Point _position;
        [DataMember]
        private static int _number = 0;

        [DataMember]
        public int ID { get; set; }
        //[DataMember]
        //public Brush Color { get; set; }
        [DataMember]
        public static List<FoodPoint> FoodPoints = new List<FoodPoint>();
        
        public static void CreateFood()
        {
            Random r = new Random();
            for (int i = 0; i <= 10; i++)
            {
                int x = r.Next(10, 550);
                int y = r.Next(10, 350);
                FoodPoints.Add(new FoodPoint(x, y));
            }
        }
        
        public static bool TrySetPosition(int x, int y)
        {
            double minDistance = 10; //Минимальная дистанция между точками двумя точками
            double r; //Расстояние между двумя точками
            foreach(FoodPoint food in FoodPoint.FoodPoints)
            {
                r = Math.Sqrt(Math.Pow(food.Position.X+5 - x+5, 2) + Math.Pow(food.Position.Y+5 - y+5, 2));
                if(minDistance < r)
                {
                    return false;
                }
            }
            return true;
        }

        public FoodPoint(int x, int y)
        {
            //Color = GetRandomColor();
            _position = new Point(x, y);
            ID = _number;

            _number++;
        }
        public FoodPoint(int x, int y, int id)
        {
            //Color = GetRandomColor();
            _position = new Point(x, y);
            ID = id;


        }


        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private Brush GetRandomColor()
        {
            Random r = new Random();
            SolidColorBrush solidColorBrush = new SolidColorBrush();
            solidColorBrush.Color = System.Windows.Media.Color.FromRgb((Byte)r.Next(0, 255), (Byte)r.Next(0, 255), (Byte)r.Next(0, 255));
            return solidColorBrush;
        }
    }
}