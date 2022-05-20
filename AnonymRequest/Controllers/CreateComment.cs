using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Models;
using AnonymRequest.Logic.FILES;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.COMMENT;
using AnonymRequest.Logic.COMMENTFILES;
using AnonymRequest.Logic;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using System.Net;

namespace AnonymRequest.Controllers
{
    public class CreateComment : Controller
    {
        private readonly ITICKETS Tickets;
        private readonly ICOMMENT Comment;
        private readonly IFILES Files;
        private readonly ICOMMENTFILES CommentFiles;


        public CreateComment(ITICKETS tickets, ICOMMENT comment, IFILES files, ICOMMENTFILES commentfiles)
        {
            Tickets = tickets;
            Comment = comment;
            Files = files;
            CommentFiles = commentfiles;
        }

        [HttpPost]
        [Route("api/view")]
        public async Task<string> Create_Comment([FromBody] CommentRequest comment)
        {
            var ticket_id = await Tickets.GetTicketByGuid(comment.Gid);
            bool is_logged = comment.IsLogged == "true" ? true : false;
            long time = System.Convert.ToInt64(comment.Time);
            var comment_id = await Comment.Create_Comment(is_logged,comment.Text, time, ticket_id);
            int files_number = comment.Files.Length;
            

            for (int i = 0; i < files_number; i++)
            {
                js_file file = new js_file(comment.Files[i].Name, comment.Files[i].Code);
                var id_file = await Files.Push_File(file);
                await CommentFiles.CreateCommentFiles(comment_id, id_file);
            }

            var comments = await Comment.GetCommentsByTicketId(ticket_id, comment.Files);

            return new CommentResponse(comments).ToString();
        }
    }
}