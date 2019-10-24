
using DowntimeAlerter.ApplicationLayer.IServices;
using DowntimeAlerter.ApplicationLayer.Repository;
using DowntimeAlerter.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DowntimeAlerter.ApplicationLayer.Services
{
    
    public class HealthCheckService : BaseService<HealthCheck>, IHealthCheckService
    {
        IGenericRepository<HealthCheck> _repository;
        public HealthCheckService(IGenericRepository<HealthCheck> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
