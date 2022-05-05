using AnonymRequest.Storage.Entities;

namespace AnonymRequest.Logic.Users;

public interface IUser
{
    Task<IList<User>>GetAll();
    Task Create(string token);
    Task Delete(int Id);
}
