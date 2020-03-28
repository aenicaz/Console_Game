using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WcfService.Engine
{
    [DataContract]
    public class Player
    {
        private string _login;
        [DataMember]
        private Color _color;
        [DataMember]
        private Point _position;

        public Player(string login)
        {
            _login = login;
            _color = GetRandomColor();
        }


       
        private Color GetRandomColor()
        {
            Random rand = new Random();
            int r = rand.Next(0,255);
            int g = rand.Next(0, 255);
            int b = rand.Next(0, 255);

            return Color.FromArgb(r,g,b);
        }
    }
}
