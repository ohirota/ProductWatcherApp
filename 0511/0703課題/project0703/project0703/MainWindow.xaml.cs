
using Project0703.Models;
using Project0703.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Project0703
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is DataGrid grid && grid.SelectedItem is ProductionLine selectedLine)
            {
                var detailWindow = new DetailWindow(selectedLine);
                detailWindow.ShowDialog();
            }
        }
    }
}
