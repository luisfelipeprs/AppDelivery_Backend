using AppDelivery.Domain.Repositories.User;
using AutoMapper;

namespace AppDelivery.Application.UseCases.User
{
    public class GetUsersUseCase : IGetUsersUseCase, IGetUserByIdUseCase
    {
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IMapper _mapper;

        public GetUsersUseCase(
            IUserReadOnlyRepository readOnlyRepository,
            IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;

        }

        public async Task<List<Domain.Entities.User>> GetUsers()
        {
            var users = await _readOnlyRepository.GetUsers();
            return users;
        }

        public async Task<Domain.Entities.User> Execute(long Id)
        {
            var users = await _readOnlyRepository.GetUserById(Id);
               
            return users!;
        }
    }
}
