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
        private ObservableCollection<FieldRow<Cell>>? field = FieldGenerator.Generate(10);

        public int Size
        {
            get
            {
                return field == null ? 0 : field.Count;
            }
            set
            {
                field = FieldGenerator.Generate(value);
                OnPropertyChanged("Size");
            }
        }
        public ObservableCollection<FieldRow<Cell>>? Field
        {
            get
            {
                return field;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
