using Microsoft.AspNetCore.Mvc;
using DigitalDetoxSystem.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http.Json;

namespace DigitalDetoxSystem.Controllers
{
    public class UsageLogsController : Controller
    {
        private readonly DigitalDetoxDBContext _context;

        public UsageLogsController(DigitalDetoxDBContext context)
        {
            _context = context;
        }

        // 顯示輸入表單
        public IActionResult Create()
        {
            return View();
        }

        // 接收表單輸入並儲存
        [HttpPost]
        public IActionResult Create(UsageLog log)
        {
            if (ModelState.IsValid)
            {
                log.Id = Guid.NewGuid(); // 產生新的 GUID
                _context.UsageLogs.Add(log);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(log);
        }

        // 顯示歷史紀錄
        public IActionResult Index()
        {
            var logs = _context.UsageLogs.OrderByDescending(l => l.Timestamp).ToList();
            DateTime today = DateTime.Today;

            #region UI上今天的紀錄
            // 篩選今天的記錄
            var todayLogs = logs.Where(l => l.Timestamp.Date == today).ToList();

            // 計算統計數據
            int seriousCount = todayLogs.Count(l => l.Type == "認真");
            int relaxCount = todayLogs.Count(l => l.Type == "放鬆");

            TimeSpan seriousTotalTime = TimeSpan.FromMinutes(seriousCount * 30);
            TimeSpan relaxTotalTime = TimeSpan.FromMinutes(relaxCount * 15);

            double seriousAvgTime = seriousCount > 0 ? seriousTotalTime.TotalMinutes / seriousCount : 0;
            double relaxAvgTime = relaxCount > 0 ? relaxTotalTime.TotalMinutes / relaxCount : 0;
            #endregion

            // 計算最近 7 天的記錄數
            var last7Days = Enumerable.Range(0, 7)
                .Select(i => today.AddDays(-i))
                .OrderBy(d => d)
                .ToList();

            var last30Days = Enumerable.Range(0, 30)
                .Select(i => today.AddDays(-i))
                .OrderBy(d => d)
                .ToList();

            var dailyUsage = last7Days.Select(date => new
            {
                Date = date.ToString("yyyy-MM-dd"),
                SeriousCount = logs.Count(l => l.Type == "認真" && l.Timestamp.Date == date),
                RelaxCount = logs.Count(l => l.Type == "放鬆" && l.Timestamp.Date == date)
            }).ToList();


            // 建立 ViewModel
            var viewModel = new UsageLogStatisticsViewModel
            {
                SeriousCount = seriousCount,
                RelaxCount = relaxCount,
                SeriousTotalTime = seriousTotalTime.TotalMinutes,
                RelaxTotalTime = relaxTotalTime.TotalMinutes,
                SeriousAvgTime = seriousAvgTime,
                RelaxAvgTime = relaxAvgTime,
                Logs = logs,
                Last7DaysUsageJson = System.Text.Json.JsonSerializer.Serialize(dailyUsage)
            };

            return View(viewModel);
        }
    }
}
