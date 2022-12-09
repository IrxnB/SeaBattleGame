using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleGame
{
    internal class FieldGenerator
    {
        private readonly Random random = new Random();
        public ObservableCollection<ObservableCollection<Cell>> Generate(int size, out int shipsCount)
        {

            shipsCount = 0;

            var field = new ObservableCollection<ObservableCollection<Cell>>();
            for(int row = 0; row < size; row++)
            {
                field.Add(new ObservableCollection<Cell>());
                for(int column = 0; column < size; column++)
                {
                    bool isShip = IsNextShip(random);
                    shipsCount += isShip ? 1 : 0;
                    field.ElementAt(row).Add(new Cell(isShip));
                }
            }
            return field;
        }
        private bool IsNextShip(Random random)
        {
            return random.NextDouble() < 0.3;
        }
    }
 }
