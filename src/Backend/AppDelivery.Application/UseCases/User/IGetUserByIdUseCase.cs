using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.User;
public interface IGetUserByIdUseCase
    {
        Task<Domain.Entities.User> Execute(Guid id);
    }
