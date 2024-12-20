﻿namespace AppDelivery.Domain.Repositories.User;
public interface IUserWriteOnlyRepository
{
    public Task Add(Entities.User user);
    Task<bool> Delete(Guid id);
}
