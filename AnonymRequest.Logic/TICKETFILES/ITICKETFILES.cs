namespace AnonymRequest.Logic.TICKETFILES
{
    public interface ITICKETFILES
    {
        public Task Bind_Ticket_File(int id_file, int id_ticket);
        public Task<File?[]> GetFilesByTicketInfoId(int ticketInfo_id);
    
    }

}

