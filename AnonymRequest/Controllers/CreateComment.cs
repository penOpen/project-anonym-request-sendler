using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Models;
using AnonymRequest.Logic.FILES;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.COMMENT;
using AnonymRequest.Logic.COMMENTFILES;
using AnonymRequest.Logic;



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

        [HttpPut]
        [Route("api/View")]
        public async Task Create_Comment([FromBody] CommentRequest comment)
        {
            var ticket_id = await Tickets.GetTicketByGuid(comment.Gid);
            var comment_id = await Comment.Create_Comment(comment.IsLogged,comment.Text, comment.Time, ticket_id);
            int files_number = comment.Files.Length;
            for (int i = 0; i < files_number; i++)
            {
                js_file file = new js_file(comment.Files[i].Name, comment.Files[i].Code);
                var id_file = await Files.Push_File(file);
                await CommentFiles.CreateCommentFiles(comment_id, id_file);
            }
        }
    }
}