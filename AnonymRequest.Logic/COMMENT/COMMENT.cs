
namespace AnonymRequest.Logic.COMMENT

{
    public class COMMENT:ICOMMENT
    {
        private readonly Context _context;

        public COMMENT(Context context)
        {
            _context = context;
        }

        public async Task<int> Create_Comment()
        {
            var new_Comment = new Comment{is_mod = false, text = "-1", time = -1};
             _context.Add(new_Comment);
            var id_comment = new_Comment.Id;
            Console.WriteLine(id_comment);
            await _context.SaveChangesAsync();
            int new_comment = _context.Comments.OrderByDescending(p => p.Id).LastOrDefault().Id;
            return new_comment;
        }
    }
}