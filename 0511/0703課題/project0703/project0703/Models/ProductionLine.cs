using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0703.Models
{
    public class ProductionLine
    {
        public int Id { get; set; }
        public string LineName { get; set; }
        public LineStatus Status { get; set; }
        public string Manager { get; set; }
        // コンストラクタ

        public enum LineStatus
        {
            稼働中,
            停止,
            メンテナンス
        }
    }
}
