namespace AnonymRequest.Logic.TICKETS
{
    public interface ITICKETS
    {
        public Task<int> Create_Tickets(int ticket_info_id);
        public Task<string> GetGuidById(int id);
    }
}