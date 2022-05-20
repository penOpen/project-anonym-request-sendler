
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
            var new_Comment = new Comment{is_mod = _is_mod, text = _text, time = _time, ticket_id = _ticket_id};
             _context.Add(new_Comment);
            await _context.SaveChangesAsync();
            var id_comment = new_Comment.Id;
            return id_comment;
        }
    }
}