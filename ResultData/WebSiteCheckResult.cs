using System;

namespace ConnectionCheckerConsoleApp.ResultData
{
    public class WebSiteCheckResult
    {
        public string Adress { get; set; }

        public DateTime CheckDataTime { get; set; }

        public bool HostAvailable { get; set; }
    }
}