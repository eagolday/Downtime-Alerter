using DowntimeAlerter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DowntimeAlerter.Domain.Entities
{
    [Table("HealthChecks")]
    public class HealthCheck : BaseEntity,  ISoftDelete
    {
        [DefaultValue(false)]
        public DateTime CheckDate { get; set; }
        public bool IsDeleted { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; }

        public Guid MonitorId { get; set; }
        [ForeignKey("MonitorId")]
        public Monitor Monitor { get; set; }


    }
}
