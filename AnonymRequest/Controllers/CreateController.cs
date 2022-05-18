using AnonymRequest.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Logic.TICKETGUID;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.FILES;
using AnonymRequest.Logic.COMMENT;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.TICKETTOKEN;
using AnonymRequest.Storage;
using Microsoft.EntityFrameworkCore;
using AnonymRequest.Logic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Net;
using AnonymRequest.Models;

namespace AnonymRequest.Controllers

{
    public class CreateController : Controller
    {
        private readonly ITICKETGUID Ticketguid;
        private readonly ITICKETINFO Ticketinfo;
        private readonly IFILES Files;
        private readonly ICOMMENT Comments;
        private readonly ITICKETS Tickets;
        private readonly ITICKETTOKEN Tickettoken;

        public CreateController(ITICKETGUID guid, ITICKETINFO info, IFILES files, ICOMMENT comment, ITICKETS ticket, ITICKETTOKEN tickettoken)
        {
            Ticketguid = guid;
            Ticketinfo = info;
            Files = files;
            Comments = comment;
            Tickets = ticket;
            Tickettoken = tickettoken;

        }

        [HttpPost]
        [Route("Create")]
        public async Task<string> Create([FromBody] CreateRequest _js_file)
        {
            var info = new js_parsed(_js_file.type, _js_file.name,_js_file.description);
            var files = new js_file(_js_file.js_name, _js_file.js_code);

            Console.WriteLine("Done");
            var id_file = await Files.Push_File(files);
            var id_comment = await Comments.Create_Comment();
            Console.WriteLine("Done");
            var id_ticket = await Ticketinfo.Generate_Ticket(info, id_file, id_comment);
            Console.WriteLine("Done");
            var Token = await Ticketguid.Generate_Token(id_ticket);
            var id_ticket_tickets = await Tickets.Create_Tickets(info.type, id_ticket);
            var master_key = await Tickettoken.Create_Ticket_Token(id_ticket_tickets, Token);
            return master_key;
        }


    }
}