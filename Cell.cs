using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleGame
{
    internal class Cell : INotifyPropertyChanged
    {
        private bool _isShip;
        private bool _isOpened = false;

        public Cell(bool isShip) {
            _isShip = isShip;
        }
        public bool IsShip
        {
            get { return _isShip; }
        }
        public Color color
        {
            get
            {
                return _isOpened? Color.LightGray : _isShip? Color.Red : Color.DarkGray;
            }
        }


        public bool IsOpened
        {
            get 
            { 
                return _isOpened; 
            }
            set 
            { 
                _isOpened = value;
                OnPropertyChanged("IsOpened");
                OnPropertyChanged("Color");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
