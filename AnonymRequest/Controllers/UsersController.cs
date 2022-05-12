using System.Text.Json;
using AnonymRequest.Logic.Users;
using AnonymRequest.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnonymRequest.Controllers;

public class UsersController : Controller
{
    private readonly IUser _user;

    public UsersController(IUser user)
    {
        _user = user;
    }

    [HttpPut]
    [Route("users")]
    public Task Create() => _user.Create();
    
}
