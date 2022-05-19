using AnonymRequest.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.FILES;
using AnonymRequest.Logic.COMMENT;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.TICKETTOKEN;
using AnonymRequest.Logic.TICKETFILES;
using AnonymRequest.Storage;
using AnonymRequest.Models;

namespace AnonymRequest.Controllers 
{
    public class ViewController : Controller
    {
        private readonly ITICKETINFO Ticketinfo;
        private readonly IFILES Files;
        private readonly ICOMMENT Comments;
        private readonly ITICKETS Tickets;
        private readonly ITICKETTOKEN Tickettoken;
        private readonly ITICKETFILES Ticketfiles;
        public ViewController(ITICKETINFO info, IFILES files, ICOMMENT comment, ITICKETS ticket, ITICKETTOKEN tickettoken, ITICKETFILES add_Files)
        {

            Ticketinfo = info;
            Files = files;
            Comments = comment;
            Tickets = ticket;
            Tickettoken = tickettoken;
            Ticketfiles = add_Files;
        }


        [HttpGet]
        [Route("api/view")]
        public async Task<string> ViewGet([FromBody] ViewRequest _js_file)// ticket id <= guid, ticket id => token
        {
            var ticket_id = await Tickets.GetTicketByGuid(_js_file.Gid);
            if (ticket_id == -1) return new ViewResponse(false, "0", "0", null, "0", null, null).ToString();
            var token = await Tickettoken.GetTokenByGuid(_js_file.Gid);
            if (token == "-1" || token != _js_file.Token) return new ViewResponse(false, "0", "0", null, "0", null, null).ToString();
            

            var ticket = await Tickets.GetTicketByID(ticket_id);
            var ticketfiles = await Ticketfiles.GetFilesByTicketInfoId(ticket.id_ticketinfo);
            var ticketInfo = await Ticketinfo.Get_TicketInfo(ticket.id_ticketinfo);

            return new ViewResponse(true, ticketInfo.name, ticketInfo.description, ticketfiles, ticketInfo.status, null, null).ToString();
        }
    }
}
