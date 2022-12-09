using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SeaBattleGame
{
    public static class Config
    {
        public static class Colors
        {
            public static readonly Color SHIP = Color.FromRgb(255, 10, 10);
            public static readonly Color EMPTY_SPACE = Color.FromRgb(100, 100, 100);
            public static readonly Color CLOSED = Color.FromRgb(50, 50, 50);
        }
    }
}
