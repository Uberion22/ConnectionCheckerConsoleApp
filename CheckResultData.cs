using System.Collections.Generic;

namespace TestService
{
    public class CheckResultData
    {
        public DatabaseServerCheckResult DatabaseServerCheckResult { get; set; }

        public IEnumerable<WebSiteCheckResult> WebSiteCheckResults { get; set; }
    }
}
