using AnonymRequest.Logic.Users;
using AnonymRequest.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AnonymRequest.Controllers;

public class UsersController : Controller
{
    private readonly IUser _user;

    public UsersController(IUser user)
    {
        _user = user;
    }

    [HttpGet]
    [Route("users")]
    public async Task<IList<User>> GetAll() => await _user.GetAll();
}
