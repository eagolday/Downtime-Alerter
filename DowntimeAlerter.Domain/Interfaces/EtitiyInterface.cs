using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DowntimeAlerter.Domain.Interfaces
{

    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }

    public interface IPassivable
    {
        bool IsActive { get; set; }
    }
}
