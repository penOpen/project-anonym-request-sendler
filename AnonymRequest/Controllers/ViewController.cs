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
using AnonymRequest.Logic.COMMENTFILES;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using System.Net;

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
        private readonly ICOMMENTFILES CommentFiles;
        public ViewController(ITICKETINFO info, IFILES files, ICOMMENT comment, ITICKETS ticket, ITICKETTOKEN tickettoken, ITICKETFILES add_Files, ICOMMENTFILES commentfiles)
        {

            Ticketinfo = info;
            Files = files;
            Comments = comment;
            Tickets = ticket;
            Tickettoken = tickettoken;
            Ticketfiles = add_Files;
            CommentFiles = commentfiles;

        }


        [HttpPost]
        [Route("api/view")]
        public async Task<string> ViewGet([FromBody] ViewRequest _js_file)// ticket id <= guid, ticket id => token
        {
            var ticket_id = await Tickets.GetTicketByGuid(_js_file.Gid.ToUpper());
            if (ticket_id == -1) return new ViewResponse(false, "0", "0", null, "0", null, null).ToString();
            var token = await Tickettoken.GetTokenByGuid(_js_file.Gid);
            if (token == "-1" || token != _js_file.Token) return new ViewResponse(false, "0", "0", null, "0", null, null).ToString();
            

            var ticket = await Tickets.GetTicketByID(ticket_id);
            var ticketfiles = await Ticketfiles.GetFilesByTicketInfoId(ticket.id_ticketinfo);
            var ticketInfo = await Ticketinfo.Get_TicketInfo(ticket.id_ticketinfo);

            return new ViewResponse(true, ticketInfo.name, ticketInfo.description, ticketfiles, ticketInfo.status, null, null).ToString();
        }

        [HttpPut]
        [Route("api/view")]
        public async Task<string> Create_Comment([FromBody] CommentRequest comment)
        {
            var ticket_id = await Tickets.GetTicketByGuid(comment.Gid);
            bool is_logged = comment.IsLogged == "true" ? true : false;
            long time = System.Convert.ToInt64(comment.Time);
            var comment_id = await Comments.Create_Comment(is_logged, comment.Text, time, ticket_id);
            int files_number = comment.Files.Length;


            for (int i = 0; i < files_number; i++)
            {
                Logic.File file = new Logic.File(comment.Files[i].name, comment.Files[i].code);
                var id_file = await Files.Push_File(file);
                await CommentFiles.CreateCommentFiles(comment_id, id_file);
            }

            var comments = await Comments.GetCommentsByTicketId(ticket_id, comment.Files);

            return new CommentResponse(comments).ToString();
        }
    }
}
