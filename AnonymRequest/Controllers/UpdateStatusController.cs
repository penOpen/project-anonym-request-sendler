using Microsoft.AspNetCore.Mvc; 
using AnonymRequest.Logic.MOD;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Models;
namespace AnonymRequest.Controllers
{
    public class UpdateStatusController : Controller
    {
        private readonly IMOD Mod;
        private readonly ITICKETS Tickets;
        private readonly ITICKETINFO Ticketinfo;

        public UpdateStatusController(IMOD mod, ITICKETS tickets, ITICKETINFO ticketinfo)
        {
            Mod = mod;
            Tickets = tickets;
            Ticketinfo = ticketinfo;
        }

        [HttpPut]
        [Route("api/account")]
        public async Task<string> Update_Status([FromBody] UpdateRequest update)
        {
            if (Mod.Find_Moderator(update.Token) == null)
            {
                return new UpdateResponse("false").ToString();
            }
                var ticketinfo_id = await Tickets.GetTicketInfoIDbyGUID(update.Gid);

            if (ticketinfo_id == -1)
            {
                return new UpdateResponse("false").ToString();
            }

            await Ticketinfo.Update_Status(ticketinfo_id, update.Status);

            return new UpdateResponse("true").ToString();
        }
    }
}