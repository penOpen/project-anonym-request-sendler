namespace AnonymRequest.Storage.Entities
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; } // id тикета
        public int id_mod { get; set; } // id модера
        int id_ticketinfo { get; set; }// id ticketinfo
        int id_comments { get; set; }// id коммента
        int status { get; set; } // 1 из 4 возможных статусов

        [ForeignKey(nameof(id_mod))]
        public virtual Mod Mod { get; set; }

        [ForeignKey(nameof(id_ticketinfo))]
        public virtual TicketInfo Ticketinfo { get; set; }

        [ForeignKey(nameof(id_comments))]
        public virtual Comment Comment { get; set; }
    }
}