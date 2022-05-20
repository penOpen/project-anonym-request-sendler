
namespace AnonymRequest.Logic.COMMENT

{
    public class COMMENT : ICOMMENT
    {
        private readonly Context _context;

        public COMMENT(Context context)
        {
            _context = context;
        }

        public async Task<int> Create_Comment(bool _is_mod, string _text, long _time, int _ticket_id)
        {
            var new_Comment = new Comment { is_mod = _is_mod, text = _text, time = _time, ticket_id = _ticket_id };
            _context.Add(new_Comment);
            await _context.SaveChangesAsync();
            var id_comment = new_Comment.Id;
            return id_comment;
        }
        public async Task<Logic.Comments?[]> GetCommentsByTicketId(int Ticket_id)
        {            
            var comments = await _context.Comments.Where(p => p.ticket_id == Ticket_id).ToListAsync();
            var returnComments = new List<Comments>();
            foreach (var comment in comments)
            {
                List<File> commentFiles = new List<File>();

                var linkes = await _context.CommentFiles.Where(p => p.comment_id == comment.Id).ToListAsync();
                foreach (var link in linkes)
                {
                    var raw_file = await _context.Files.FindAsync(link.file_id);
                    commentFiles.Add(new File(raw_file.Name, raw_file.url));
                }
                
                var comment_st = new Comments(comment.Id, comment.is_mod, comment.text, commentFiles.ToArray(), comment.time);
                returnComments.Add(comment_st);
            }
            return returnComments.ToArray();
        }
    }
}

namespace AnonymRequest.Logic
{
    public class Comments
    {
        public int id { get; set; }
        public bool isMod { get; set; }
        public string text { set; get; }
        public long time { get; set; }
        public Logic.File?[] files { get; set; }

        public Comments(int Id, bool IsMod, string Text, Logic.File?[] Files, long Time)
        {
            id = Id;
            isMod = IsMod;
            text = Text;
            files = Files;
            time = Time;
        }
    }
}