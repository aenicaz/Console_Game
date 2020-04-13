using ClientWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ClientWPF.Model
{
    class Controls
    {

        private static double speed = 4;
        
        public static void MoveLeft(ClientPlayer player)
        {
            Point pos = player.Position;
            pos.X -= speed;
            player.Position = pos;
        }
        public static void MoveRight(ClientPlayer player)
        {
            Point pos = player.Position;
            pos.X += speed;
            player.Position = pos;
        }
        public static void MoveTop(ClientPlayer player)
        {
            Point pos = player.Position;
            pos.Y -= speed;
            player.Position = pos;
        }
        public static void MoveDown(ClientPlayer player)
        {
            Point pos = player.Position;
            pos.Y += speed;
            player.Position = pos;
        }

    }
}
