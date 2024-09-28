using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDelivery.Application.UseCases.Driver
{
    public interface IGetDriverUseCase
    {
        public Task<List<Domain.Entities.Driver>> GetDrivers();
    }
}
