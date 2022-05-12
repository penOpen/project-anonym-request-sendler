using AnonymRequest.Storage.Entities;

namespace AnonymRequest.Logic.Users;

public interface IUser 
{
    Task Create_User();
    Task Find_User(string Token);
    //createUser 
}




/*public interface IUser
{
    Task<IList<User>>GetAll();
    Task Create(string token);
    Task Delete(int Id);
}*/
