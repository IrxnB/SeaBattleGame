using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeaBattleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new GameField();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var gameField = (GameField)DataContext;
            gameField.InitializeField();
            var field = gameField.Field;
            MainPanel.Children.Clear();
            MainPanel.Width = Window.Width; MainPanel.Height = Window.Width;
            foreach(var row in field)
            {
                var horizontalPanel = new StackPanel();
                horizontalPanel.Orientation = Orientation.Horizontal;
                MainPanel.Children.Add(horizontalPanel);
                foreach(var cell in row)
                {
                    var button = new Button();
                    button.Width = MainPanel.Width / gameField.Size;
                    button.Height = MainPanel.Width / gameField.Size;
                    horizontalPanel.Children.Add(button);

                    buttonCellBind(button, cell);
                    
                    button.Click += (sender, e) =>
                        {
                            if (gameField.MakeClick(cell))
                            {
                                MessageBox.Show($"You won! Turns:{gameField.TurnCount}");
                            }
                        };
                    StartButton.Name = "Restart";
                }
            }
            
        }
        private static void buttonCellBind(Button button, Cell cell)
        {
            SolidColorBrush brush = new SolidColorBrush();
            Binding colorBind = new Binding("Brush");
            colorBind.Source = cell;
            button.SetBinding(BackgroundProperty, colorBind);
        }
    }
}
