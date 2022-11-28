using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleGame
{
    internal class FieldRow<T>
    {
        private ObservableCollection<T> _row = new();

        public ObservableCollection<T> Row
        {
            get
            {
                return _row;
            }
        }

    }
}
