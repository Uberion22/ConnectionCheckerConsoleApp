using Npgsql;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TestService
{
    internal class SiteChecker
    {
        private static async Task<WebSiteCheckResult> CheckSiteAsync(string adress)
        {
            var result = new WebSiteCheckResult() { Adress = adress };
            WebRequest request = WebRequest.Create(adress);
            try
            {
                using HttpWebResponse response = (HttpWebResponse)
                await request.GetResponseAsync();
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    result.HostAvailable = true;
                }
            }
            catch (WebException ex)
            {
                result.HostAvailable = false;
            }
            finally
            {
                result.CheckDataTime = DateTime.Now;
            }

            return result;
        }

        public static List<WebSiteCheckResult> CheckWebSItesByAdresesList(List<string> adresses)
        {
            var tasks = new Task<WebSiteCheckResult>[adresses.Count];
            var result = new List<WebSiteCheckResult>();
            
            for(int i = 0; i < adresses.Count; i++)
            {
                var index = i;
                tasks[index] = Task.Run(() => CheckSiteAsync(adresses[index]));
            }

            Task.WaitAll(tasks);

            foreach (var task in tasks)
            {
                result.Add(task.Result);
            }

            return result;
        }

        public static DatabaseServerCheckResult CheckDBConnection(string connectionString)
        {
            var result = new DatabaseServerCheckResult { ConnectionString = connectionString };
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                conn.Open();
                result.CheckDataTime = DateTime.UtcNow;
                result.DataBaseAvailable = true;
                
                return result;
            }
            catch
            {
                result.CheckDataTime = DateTime.UtcNow;
                
                return result;
            }
        }
    }
}
