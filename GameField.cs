using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleGame
{
    internal class GameField : INotifyPropertyChanged
    {
        private ObservableCollection<ObservableCollection<Cell>> _field;
        private FieldGenerator fg;
        private int _targetSize = 0;
        private int _turnCount = 0;
        private int _shipsLeft;

        public GameField()
        {
            fg = new FieldGenerator();
            _field = fg.Generate(0, out _shipsLeft);
        }

        public int TurnCount
        {
            get
            {
                return _turnCount;
            }
        }
        public int TargetSize
        {
            get 
            { 
                return _targetSize;
            }
            set 
            { 
                _targetSize = value;
                OnPropertyChanged("TargetSize");
            }
        }
        public int Size
        {
            get
            {
                return _field == null ? 0 : _field.Count;
            }
        }
        public ObservableCollection<ObservableCollection<Cell>>? Field
        {
            get
            {
                return _field;
            }
        }

        public void InitializeField()
        {
            _field = fg.Generate(TargetSize, out _shipsLeft);
            _turnCount = 0;
        }

        public bool MakeClick(Cell cell)
        {
            if (!cell.Click())
            {
                _turnCount++;
                _shipsLeft -= cell.IsShip ? 1 : 0;
            }
            return _shipsLeft <= 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
