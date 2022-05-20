namespace AnonymRequest.Logic.COMMENT
{
    public interface ICOMMENT
    {
         public Task<int> Create_Comment(bool _is_mod, string _text, long _time, int _ticket_id);
         public Task<Logic.Comments?[]> GetCommentsByTicketId(int ticlet_id, File?[] commentfiles);
    }
}