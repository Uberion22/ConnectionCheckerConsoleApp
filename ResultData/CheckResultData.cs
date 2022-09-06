using System.Collections.Generic;

namespace TestService.ResultData
{
    public class CheckResultData
    {
        public IEnumerable<DatabaseServerCheckResult> DatabaseServerCheckResult { get; set; }

        public IEnumerable<WebSiteCheckResult> WebSiteCheckResults { get; set; }
    }
}