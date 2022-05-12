using System.Text.Json;
using AnonymRequest.Storage.Entities;

namespace AnonymRequest.Logic.Users;

public interface IUser
{
    Task FindUser(string Token);
    Task Create();
    Task Delete(int Id);
    Task Get { get; }
}
