using System;

namespace TestService
{
    public class WebSiteCheckResult
    {
        public string Adress { get; set; }
        
        public DateTime CheckDataTime { get; set; }
        
        public bool HostAvailable { get; set; }
    }
}
