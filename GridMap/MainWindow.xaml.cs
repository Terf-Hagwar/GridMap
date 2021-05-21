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

namespace GridMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Init(5, 5);
        }

        private GridLength gl = new GridLength(25);

        private void Init(int maxRow, int maxCol)
        {
            this.MapGrid.Children.Clear();
            this.MapGrid.RowDefinitions.Clear();
            this.MapGrid.ColumnDefinitions.Clear();

            for (var i = 0; i < maxRow; i++)
            {
                this.MapGrid.RowDefinitions.Add(new RowDefinition() { Height = gl });
            }

            for (var k = 0; k < maxCol; k++)
            {
                this.MapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = gl });
            }

            var cells = new List<MapCell>();
            for (var i = 0; i < maxRow; i++)
            {
                for (var k = 0; k < maxCol; k++)
                {
                    var cell = new MapCell() { X_Point = k, Y_Point = i };
                    if (((i + k) % 2) == 0)
                    {
                        cell.CellType = "○";
                        cell.CellColor = new SolidColorBrush(Colors.Blue);
                    }
                    if (((i + k) % 5) == 0)
                    {
                        cell.CellType = "×";
                        cell.CellColor = new SolidColorBrush(Colors.Red);
                    }
                    cells.Add(cell);
                }
            }

            foreach (var cell in cells)
            {

                var b = new Button()
                {
                    Content = cell.CellType,
                    Background = cell.CellColor
                };
                b.SetValue(Grid.RowProperty, cell.Y_Point);
                b.SetValue(Grid.ColumnProperty, cell.X_Point);

                this.MapGrid.Children.Add(b);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var y = this.SetY.Text;
            var x = this.SetX.Text;

            try
            {
                this.Init(int.Parse(y), int.Parse(x));
            }
            catch (Exception)
            {
            }
        }
    }

    public class MapCell
    {
        public int X_Point { get; set; }
        public int Y_Point { get; set; }

        public string CellType { get; set; } = "unknown";

        public SolidColorBrush CellColor { get; set; } = new SolidColorBrush(Colors.Black);
    }
}
