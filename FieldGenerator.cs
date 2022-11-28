using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleGame
{
    static internal class FieldGenerator
    {
        public static ObservableCollection<FieldRow<Cell>> Generate(int size)
        {
            Random random = new Random();
            var field = new ObservableCollection<FieldRow<Cell>>();
            for(int row = 0; row < size; row++)
            {
                field.Add(new FieldRow<Cell>());
                for(int column = 0; column < size; column++)
                {
                    field.ElementAt(row).Row.Add(new Cell(random.NextDouble() > 0.3));
                }
            }
            return field;
        }
    }
 }
