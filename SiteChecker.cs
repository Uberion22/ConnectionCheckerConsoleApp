using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TestService
{
    internal class SiteChecker
    {
        private static async Task<CheckResultModel> CheckSite(string adress)
        {
            var result = new CheckResultModel() { Adress = adress };
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

        public static List<CheckResultModel> CheckWebSItesByAdresesList(List<string> adresses)
        {
            var tasks = new Task<CheckResultModel>[adresses.Count];
            var result = new List<CheckResultModel>();
            
            for(int i = 0; i < adresses.Count; i++)
            {
                var index = i;
                tasks[index] = Task.Run(() => CheckSite(adresses[index]));
            }

            Task.WaitAll(tasks);

            foreach (var task in tasks)
            {
                result.Add(task.Result);
            }

            return result;
        }

        //public static async Task<bool> CheckDBAsync()
        //{
        //    using OleDbConnection myConnection = new OleDbConnection(connectString);
        //    try
        //    {
        //        await myConnection.OpenAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
