using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUT.Engine
{
    class Player
    {
        private Panel _panel;
        private string _login;
        private Form _activeForm = Game.ActiveForm;
        

        public Player(string login)
        {
            _login = login;
        }

        public void DrawPlayer()
        {
            _panel = new Panel();
            _panel.Width = 32;
            _panel.Height = 32;
            _panel.Location = new Point(_activeForm.Width / 2, _activeForm.Height / 2);
            _panel.BackColor = GetRandomColor();
            _activeForm.KeyDown += Control;
            _activeForm.Focus();

            _activeForm.Controls.Add(_panel);
        }

        private void Control(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                _panel.Left += 1;
            }  
            if(e.KeyCode == Keys.W)
            {
                _panel.Top -= 1;
            }
            if (e.KeyCode == Keys.A)
            {
                _panel.Left -= 1;
            }
            if (e.KeyCode == Keys.S)
            {
                _panel.Top += 1;
            }
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
