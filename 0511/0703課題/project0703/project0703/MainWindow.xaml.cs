
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
        private void AddLineButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            var addWindow = new AddLineWindow(viewModel.StatusList);

            if (addWindow.ShowDialog() == true)
            {
                addWindow.NewLine.Id = viewModel.FilteredLines.Count + 1;
                viewModel.FilteredLines.Add(addWindow.NewLine);
            }
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.SelectedStatus = null;
            }
        }

    }
}
