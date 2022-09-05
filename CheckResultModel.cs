using System;
using System.Collections.Generic;
using System.Text;

namespace TestService
{
    internal class CheckResultModel
    {
        public string Adress { get; set; }
        public DateTime CheckDataTime { get; set; }
        public bool HostAvailable { get; set; }
    }
}
