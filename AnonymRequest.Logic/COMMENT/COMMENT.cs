
namespace AnonymRequest.Logic.COMMENT

{
    public class COMMENT
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
            await _context.SaveChangesAsync();

            return id_comment;


        }
    }
}