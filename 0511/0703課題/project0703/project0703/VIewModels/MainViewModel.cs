using CommunityToolkit.Mvvm.ComponentModel;
using Project0703.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Shapes;

namespace Project0703.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private List<ProductionLine> _allLines = new List<ProductionLine>()
        {
            new ProductionLine { Id = 1, LineName = "ラインA", Status = LineStatus.稼働中, Manager = "田中" },
            new ProductionLine { Id = 2, LineName = "ラインB", Status = LineStatus.停止, Manager = "佐藤" },
            new ProductionLine { Id = 3, LineName = "ラインC", Status = LineStatus.メンテナンス, Manager = "鈴木" },
            new ProductionLine { Id = 4, LineName = "ラインD", Status = LineStatus.稼働中, Manager = "高橋" },
        };

        public ObservableCollection<ProductionLine> FilteredLines { get; set; }
        public Array StatusList => Enum.GetValues(typeof(LineStatus));

        private LineStatus? _selectedStatus;
        public LineStatus? SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                UpdateFilter();
            }
        }

        public MainViewModel()
        {
            FilteredLines = new ObservableCollection<ProductionLine>(_allLines);
        }

        private void UpdateFilter()
        {
            var result = _selectedStatus == null
                ? _allLines
                : _allLines.Where(l => l.Status == _selectedStatus.Value).ToList();

            FilteredLines.Clear();
            foreach (var line in result)
            {
                FilteredLines.Add(line);
            }
        }

        public void AddLine(ProductionLine line)
        {
            _allLines.Add(line);
            FilteredLines.Add(line);

        }
    }
}