DigitalDetoxSystem

簡介
DigitalDetoxSystem 是一個幫助使用者減少不必要的瀏覽器使用的系統。當使用者開啟 Microsoft Edge 時，系統會要求輸入開啟瀏覽器的理由，並記錄下來以進行統計分析。

功能
強制輸入理由：使用者必須輸入開啟瀏覽器的原因。
行為記錄：儲存所有開啟瀏覽器的紀錄。

統計分析：
每日使用統計（認真 vs 放鬆）。
最近 7 天的使用趨勢（折線圖）。

自動重開瀏覽器：輸入完理由後，原本的網址會自動重新開啟。

Windows 監控程式：
監控 Microsoft Edge (msedge.exe)。
在輸入理由前，強制關閉瀏覽器。

技術
後端：ASP.NET Core MVC, Entity Framework Core, SQL Server
前端：Razor Pages, Bootstrap, ApexCharts.js
監控程式：C# Console Application, Windows API (Process.GetProcessesByName)
