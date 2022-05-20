using AnonymRequest.Storage.Entities;
namespace AnonymRequest.Logic.COMMENTFILES
{
    public class COMMENTFILES : ICOMMENTFILES
    {
        private readonly Context _context;

        public COMMENTFILES(Context context)
        {
            _context = context;
        }



        public async Task CreateCommentFiles(int _comment_id, int _file_id)
        {
            var new_comment_File = new CommentFiles{comment_id = _comment_id, file_id = _file_id};
            _context.Add(new_comment_File);
            await _context.SaveChangesAsync();
        }
    }
}