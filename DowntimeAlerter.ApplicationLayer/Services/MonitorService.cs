
using DowntimeAlerter.ApplicationLayer.IServices;
using DowntimeAlerter.ApplicationLayer.Repository;
using DowntimeAlerter.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DowntimeAlerter.ApplicationLayer.Services {

    /// <summary>
    /// Monitoring Service for Access Monitoring entities
    /// </summary>
    public class MonitorService : BaseService<Monitor>, IMonitorService
    {
        public MonitorService(IGenericRepository<Monitor> repository) : base(repository)
        {
        }
 
    }
}
