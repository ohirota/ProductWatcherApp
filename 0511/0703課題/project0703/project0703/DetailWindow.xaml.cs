using System.Windows;
using Project0703.Models;

namespace Project0703
{
    /// <summary>
    /// DetailWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DetailWindow : Window
    {
        public DetailWindow(ProductionLine line)
        {
            InitializeComponent();
            DataContext = line;
        }
    }
}
