using AppDelivery.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDelivery.Application.UseCases.Driver
{
    public interface IUpdateDriverUseCase
    {
        Task Execute(Guid Id, RequestDriverJson request);
    }
}
