using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.MOD;
using AnonymRequest.Models;
using Newtonsoft;
using AnonymRequest.Logic.TICKETTOKEN;

namespace AnonymRequest.Controllers
{
    public class ViewTicketsController : Controller
    {
        private readonly ITICKETINFO Ticketinfo;
        private readonly ITICKETTOKEN Tickettokens;
        private readonly ITICKETS Tickets;
        private readonly IMOD Mod;

        public ViewTicketsController(ITICKETINFO ticketinfo, ITICKETS tickets, IMOD mod, ITICKETTOKEN tickettokens)
        {
            Ticketinfo = ticketinfo;
            Tickettokens = tickettokens;
            Tickets = tickets;
            Mod = mod;
        }

        [HttpPost]
        [Route("api/account")]
        public async Task<string> View_Tickets_By_Type([FromBody] ViewTicketsRequest ticket_request)
        {
            var id_type = await Mod.Get_Type_Of_Moderator(ticket_request.Token);

            if (id_type == null) return new ViewTicketsResponse(false, null).ToString();

            var id_ticketinfo = await Tickets.GetTicketInfoIdbyType(id_type.Value);

            int size = id_ticketinfo.Count;
            AccountTicket[] info = new AccountTicket[size];

            for (int i = 0; i < size; i++)
            {
                var current_ticket = await Ticketinfo.Get_TicketInfo(id_ticketinfo[i]);
                var ticket_guid = await Tickets.GetGuidByTicketInfo(current_ticket.Id);
                var token = await Tickettokens.GetTokenByGuid(ticket_guid);
                info[i] = new AccountTicket(current_ticket.name, current_ticket.description, current_ticket.status, ticket_guid, token);
            }
            
            var res = new ViewTicketsResponse(true, info).ToString();
            return res;
        }

        [HttpPut]
        [Route("api/account")]
        public async Task<string> Update_Status([FromBody] UpdateRequest update)
        {
            var mod = await Mod.Find_Moderator(update.Token);
            if (mod == null)
            {
                return new UpdateResponse(false).ToString();
            }
            var ticketinfo_id = await Tickets.GetTicketInfoIDbyGUID(update.Gid);

            if (ticketinfo_id == -1)
            {
                return new UpdateResponse(false).ToString();
            }

            await Ticketinfo.Update_Status(ticketinfo_id, update.Status);

            return new UpdateResponse(true).ToString();
        }
    }
}