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

        public async Task<Logic.Comments?[]> GetCommentsByTicketId(int Ticket_id, File?[] commentfiles)
        {
            var files = commentfiles;
            var comments = new List<Comments>();
            var linkes = await _context.Comments.Where(p => p.ticket_id == Ticket_id).ToListAsync();
            foreach (var link in linkes)
            {
                var comment = new Comments(link.Id, link.is_mod, link.text, files);
                comments.Add(comment);
            }
            return comments.ToArray();
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
        public Logic.File?[] files { get; set; }

        public Comments()
        {

        }

        public Comments(int Id, bool IsMod, string Text, Logic.File?[] Files)
        {
            id = Id;
            isMod = IsMod;
            text = Text;
            files = Files;
        }
    }
}