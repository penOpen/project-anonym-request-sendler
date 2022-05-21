using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Logic.MOD;
using AnonymRequest.Models;

namespace AnonymRequest.Controllers
{
    public class LoginController : Controller
    {
        IMOD Mod;

        public LoginController(IMOD mod)
        {
            Mod = mod;
        }


        [HttpPost]
        [Route("api/login")]
        public async Task<string> Create([FromBody] LoginRequest login)
        {
            var log_back = await Mod.Find_Moderator(login.Token);
            if (log_back != null)
            {
                return new LoginResponse(login.Token, true).ToString();
            }
            else
            {
                return new LoginResponse(login.Token, false).ToString();
            }
        }


    }
}