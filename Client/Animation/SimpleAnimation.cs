using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace ClientWPF.Animation
{
    class SimpleAnimation: INotifyPropertyChanged
    {
        private string startAnim = "false";
        private Storyboard storyboard;

        public Storyboard Storyboard
        {
            get { return storyboard; }
        }


        
        public string StartAnim
        {
            get { return startAnim; }
            set { startAnim = value; OnPropertyChanged("StartAnim"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
