using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DowntimeAlerter.Domain.Enums
{
    public enum Status 
    {
        NotFound = 0,
        Success = 1,
        Error = 2
    }
}
