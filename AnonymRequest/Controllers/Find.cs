using AnonymRequest.Logic.TICKETGUID;
using AnonymRequest.Logic.TICKETINFO;

namespace AnonymRequest.Controllers
{
    public class Find
    {
        private readonly ITICKETGUID Ticketguid;
        private readonly ITICKETINFO Ticketinfo;

        public Find(ITICKETGUID guid, ITICKETINFO info)
        {
            Ticketguid = guid;
            Ticketinfo = info;
        }

        
    }
}