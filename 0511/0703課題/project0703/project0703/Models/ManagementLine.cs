using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0703.Models
{
    public class ManagementLine
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string ProductionStage { get; set; }
        public bool IsOnSchedule { get; set; }
    }
}
