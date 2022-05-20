using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.TICKETTOKEN;
using AnonymRequest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnonymRequest.Controllers
{
    public class FindController : Controller
    {
        private readonly ITICKETS Tickets;
        private readonly ITICKETTOKEN Token;

        public FindController(ITICKETS ticket, ITICKETTOKEN token)
        {
            Tickets = ticket;
            Token = token;
        }

        [HttpPost]
        [Route("api/find")]
        public async Task<string> Find([FromBody] FindRequest _js_file)
        {
            var guid = _js_file.Gid;
            var ticket = await Tickets.GetTicketByGuid(guid);

            if (ticket == -1) return new FindResponse("0", false, "0").ToString();

            var token = await Token.GetTokenByGuid(guid);
            if (token == "-1") token = await Token.Create_Ticket_Token(ticket);
 
            return new FindResponse(guid, true, token).ToString();
        }

    }
}
