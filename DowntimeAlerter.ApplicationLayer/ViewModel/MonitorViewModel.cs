using System;
using System.Collections.Generic;
using System.Text;

namespace DowntimeAlerter.ApplicationLayer.ViewModel
{
    public class MonitorViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid UserId { get; set; }
    }
}
