using DowntimeAlerter.Domain.Enums;
using DowntimeAlerter.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DowntimeAlerter.Domain.Entities
{
    [Table("Monitors")]
    public class Monitor : BaseEntity , ISoftDelete, IPassivable
    {
        public Monitor()
        {
            this.HealthChecks = new HashSet<HealthCheck>();
        }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Url { get; set; }
        public Status Status { get; set; }
        [Required]
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<HealthCheck> HealthChecks { get; set; }


    }
}
