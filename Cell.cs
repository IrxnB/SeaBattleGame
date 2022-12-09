using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using static SeaBattleGame.Config.Colors;

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
        public SolidColorBrush Brush
        {
            get
            {
                Color color = !_isOpened? CLOSED : _isShip? SHIP : EMPTY_SPACE;
                return new SolidColorBrush(color);
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
                OnPropertyChanged("Brush");
            }
        }
        public bool Click()
        {
            bool result = IsOpened;
            IsOpened = true;
            return result;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
