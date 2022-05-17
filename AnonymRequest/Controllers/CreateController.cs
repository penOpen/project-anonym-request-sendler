using AnonymRequest.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Logic.TICKETGUID;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.FILES;

namespace AnonymRequest.Controllers

{
    public class CreateController : Controller
    {
        private readonly ITICKETGUID Ticketguid;
        private readonly ITICKETINFO Ticketinfo;
        private readonly IFILES Files;

        public CreateController(ITICKETGUID guid, ITICKETINFO info, IFILES files)
        {
            Ticketguid = guid;
            Ticketinfo = info;
            Files = files;
        }

        //[HttpPost]
        //[Route("Create")]
        
        
        
    }
}