namespace AnonymRequest.Storage.Entities
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; } // id ������
        public int id_mod { get; set; } // id ������
        public int id_ticketinfo { get; set; }// id ticketinfo
        public int id_comments { get; set; }// id ��������
        public int status { get; set; } // 1 �� 4 ��������� ��������

        [ForeignKey(nameof(id_mod))]
        public virtual Mod Mod { get; set; }

        [ForeignKey(nameof(id_ticketinfo))]
        public virtual TicketInfo Ticketinfo { get; set; }

        [ForeignKey(nameof(id_comments))]
        public virtual Comment Comment { get; set; }//
    }
}