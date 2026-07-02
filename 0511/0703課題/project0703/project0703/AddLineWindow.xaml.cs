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
using System.Windows.Shapes;
using Project0703.Models;

namespace Project0703
{
    /// <summary>
    /// AddLineWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AddLineWindow : Window
    {
       public ProductionLine NewLine { get; private set; }
       
        public AddLineWindow(Array statusList)
        {
            InitializeComponent();
            StatusComboBox.ItemsSource = statusList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LineNameTextBox.Text) || string.IsNullOrEmpty(ManagerTextBox.Text) || StatusComboBox.SelectedItem == null)　　　　//理解できてなかった
            {
                MessageBox.Show("すべての項目を入力してください。");
                return;
            }

            NewLine = new ProductionLine
            {
                LineName = LineNameTextBox.Text,
                Manager = ManagerTextBox.Text,
                Status = (LineStatus)StatusComboBox.SelectedItem
            };

            DialogResult = true;        //理解できてなかった
        }
    }
}
