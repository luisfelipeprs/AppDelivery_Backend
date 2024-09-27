using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;

namespace AppDelivery.Application.UseCases;


public interface IGetUsersUseCase { 
    public Task<List<Domain.Entities.User>> GetUsers();
    //Task<Domain.Entities.User> GetUserById(long id);
}