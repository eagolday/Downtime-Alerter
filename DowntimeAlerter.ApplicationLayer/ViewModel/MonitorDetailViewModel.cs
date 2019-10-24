using System;
using System.Collections.Generic;
using System.Text;

namespace DowntimeAlerter.ApplicationLayer.ViewModel
{
    public class MonitorDetailViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime CheckDate { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        NotFound = 0,
        Success = 1,
        Error = 2
    }
}
