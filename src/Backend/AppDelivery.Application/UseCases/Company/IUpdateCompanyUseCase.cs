using AppDelivery.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDelivery.Application.UseCases.Company
{
    public interface IUpdateCompanyUseCase
    {
        Task Execute(Guid Id, RequestCompanyJson request);
    }
}
