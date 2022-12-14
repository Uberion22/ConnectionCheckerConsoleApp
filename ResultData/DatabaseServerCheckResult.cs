using System;

namespace ConnectionCheckerConsoleApp.ResultData
{
    public class DatabaseServerCheckResult
    {
        public string ConnectionString { get; set; }

        public DateTime CheckDataTime { get; set; }

        public bool DataBaseAvailable { get; set; }
    }
}