using System;
using System.ServiceProcess;
using System.Threading;

namespace TestService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sheckingService = new CheckingService();

            var ar = new string[] { "1" };
            //sheckingService.CheckWebSitesAndDataBase(args);
            sheckingService.CheckWebSitesAndDataBase(ar);
        }
    }
}
