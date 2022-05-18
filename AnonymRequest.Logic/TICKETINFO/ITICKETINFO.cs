namespace AnonymRequest.Logic.TICKETINFO
{
    public interface ITICKETINFO
    {
        public js_parsed Json_Parse(string json);
        public  Task<int> Generate_Ticket(js_parsed info, int id_file, int id_comment);
    }
}