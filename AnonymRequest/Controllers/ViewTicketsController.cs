using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.MOD;
using AnonymRequest.Models;

namespace AnonymRequest.Controllers
{
    public class ViewTicketsController : Controller
    {
        private readonly ITICKETINFO Ticketinfo;
        private readonly ITICKETS Tickets;
        private readonly IMOD Mod;

        public ViewTicketsController(ITICKETINFO ticketinfo, ITICKETS tickets, IMOD mod)
        {
            Ticketinfo = ticketinfo;
            Tickets = tickets;
            Mod = mod;
        }

        [HttpPost]
        [Route("api/account")]
        public async Task<ViewTicketsResponse[]> View_Tickets_By_Type([FromBody] ViewTicketsRequest ticket_request)
        {
           
            var id_type = await Mod.Get_Type_Of_Moderator(ticket_request.Token);
            var id_ticketinfo = await Tickets.GetTicketInfoIdbyType(id_type);
            int size = id_ticketinfo.Count;
            ViewTicketsResponse[] info = new ViewTicketsResponse[size];
            for(int i = 0; i < size; i++)
            {
                var current_ticket = await Ticketinfo.Get_TicketInfo(id_ticketinfo[i]);
                info[i].name = current_ticket.name;
                info[i].description = current_ticket.description;
                info[i].status = current_ticket.status;
            }

            return info;
        }
    }
}