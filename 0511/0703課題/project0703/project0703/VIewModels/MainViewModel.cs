using CommunityToolkit.Mvvm.ComponentModel;
using Project0703.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public Dictionary<string, int> ManagerCounts { get; set; } = new Dictionary<string, int>();
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
            ProcessLines = new ObservableCollection<ManagementLine>(_allProcesses);
            UpdateFilter();
        }

        private int activeCount;
        public int ActiveCount
        {
            get => activeCount;
            set
            {
                activeCount = value;
                OnPropertyChanged();
            }
        }

        private int stoppedCount;
        public int StoppedCount
        {
            get => stoppedCount;
            set
            {
                stoppedCount = value;
                OnPropertyChanged();
            }
        }

        private int maintenanceCount;
        public int MaintenanceCount
        {
            get => maintenanceCount;
            set
            {
                maintenanceCount = value;
                OnPropertyChanged();
            }
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

            ActiveCount = FilteredLines.Count(l => l.Status == LineStatus.稼働中);
            StoppedCount = FilteredLines.Count(l => l.Status == LineStatus.停止);
            MaintenanceCount = FilteredLines.Count(l => l.Status == LineStatus.メンテナンス);

            ManagerCounts.Clear();

            var managers = FilteredLines.Select(l => l.Manager).Distinct();

            foreach (var manager in managers)
            {
               int count = FilteredLines.Count(l =>l.Manager == manager);
                ManagerCounts[manager] = count;
            }

        }

        public void AddLine(ProductionLine line)
        {
            _allLines.Add(line);
            FilteredLines.Add(line);

        }

        private List<ManagementLine> _allProcesses = new List<ManagementLine>()
        {
            new ManagementLine { Id = 1, Category = "半導体A", ProductionStage = StageStatus.完了, IsOnSchedule = true },
            new ManagementLine { Id = 2, Category = "半導体B", ProductionStage = StageStatus.中断, IsOnSchedule = false },
            new ManagementLine { Id = 3, Category = "半導体C", ProductionStage = StageStatus.作業中, IsOnSchedule = true },
            new ManagementLine { Id = 4, Category = "半導体D", ProductionStage = StageStatus.未着手, IsOnSchedule = false },
        };

        public ObservableCollection<ManagementLine> ProcessLines { get; set; }

    }
}