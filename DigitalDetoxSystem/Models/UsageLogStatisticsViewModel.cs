using System;

namespace DigitalDetoxSystem.Models
{
    public class UsageLogStatisticsViewModel
    {
        public int SeriousCount { get; set; } // 認真次數
        public int RelaxCount { get; set; } // 放鬆次數
        public double SeriousTotalTime { get; set; } // 認真總時間（分鐘）
        public double RelaxTotalTime { get; set; } // 放鬆總時間（分鐘）
        public double SeriousAvgTime { get; set; } // 認真平均時間
        public double RelaxAvgTime { get; set; } // 放鬆平均時間
        public List<UsageLog> Logs { get; set; } // 所有歷史紀錄
        public string Last7DaysUsageJson { get; set; } // JSON 格式的統計資料

    }
}
