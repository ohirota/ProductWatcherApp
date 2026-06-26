using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ProductWatcherApp.Models;

namespace ProductWatcherApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _inputName = string.Empty;
        private int _inputPrice;

        public string InputName
        {
            get => _inputName;
            set
            {
                _inputName = value;
                OnPropertyChanged();
            }
        }

        public int InputPrice
        {
            get => _inputPrice;
            set
            {
                _inputPrice = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products { get; set; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>();

            Products.Add(new Product { ProductName = "金のネックレス", Price = 150000 });
            Products.Add(new Product { ProductName = "ジャガー・ルクルト", Price = 850000 });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
