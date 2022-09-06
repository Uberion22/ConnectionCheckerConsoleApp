using Npgsql;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ConnectionCheckerConsoleApp.ResultData;

namespace ConnectionCheckerConsoleApp.Utils
{
    public class DataBaseAndSiteChecker
    {
        private static int _connectionTimeOut;
        public static CheckResultData GetCheckResults(List<string> webAdreses, List<string> dataBaseAdreses, int timeout = 10000)
        {
            _connectionTimeOut = timeout;
            var webSiteCheckResult = CheckSomeResource(webAdreses, CheckWebSiteSAsync);
            var dataBaseCheckResult = CheckSomeResource(dataBaseAdreses, CheckDBConnectionAsync);

            var result = new CheckResultData()
            {
                WebSiteCheckResults = webSiteCheckResult,
                DatabaseServerCheckResult = dataBaseCheckResult
            };

            return result;
        }

        private static List<T> CheckSomeResource<T>(List<string> adresses, Func<string, Task<T>> usedMetod)
        {
            var tasks = new Task<T>[adresses.Count];
            var result = new List<T>();

            for (int i = 0; i < adresses.Count; i++)
            {
                var index = i;
                tasks[index] = Task.Run(() => usedMetod(adresses[index]));
            }

            Task.WaitAll(tasks);

            foreach (var task in tasks)
            {
                result.Add(task.Result);
            }

            return result;
        }

        private static async Task<WebSiteCheckResult> CheckWebSiteSAsync(string adress)
        {
            var result = new WebSiteCheckResult() { Adress = adress };
            WebRequest request = WebRequest.Create(adress);
            request.Timeout = _connectionTimeOut;
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
                Program.logger.Error(ex);
            }
            finally
            {
                result.CheckDataTime = DateTime.Now;
            }

            return result;
        }

        private static async Task<DatabaseServerCheckResult> CheckDBConnectionAsync(string connectionString)
        {
            var result = new DatabaseServerCheckResult { ConnectionString = connectionString };
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                    await conn.OpenAsync();

                result.CheckDataTime = DateTime.UtcNow;
                result.DataBaseAvailable = true;

                return result;
            }
            catch (Exception ex)
            {
                result.CheckDataTime = DateTime.UtcNow;
                Program.logger.Error(ex);

                return result;
            }
        }
    }
}
