using DowntimeAlerter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DowntimeAlerter.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
       
    }
}
