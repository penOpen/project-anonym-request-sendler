namespace AnonymRequest.Logic.TICKETS
{
    public interface ITICKETS
    {
        public Task<int> Create_Tickets(int ticket_info_id, int type_id);
        public Task<string> GetGuidById(int id);
        public Task<int> GetTicketByGuid(string guid);
        public Task<Tickets> GetTicketByID(int ticket_id);
    }
}