namespace AnonymRequest.Storage.Entities
{
    public class TicketToken
    {
        [Key]
        public int Id { get; set; }
        public long lifeend; // ��������� ����� ������

        public string token { get; set; } // �����

        public int ticket_id { get; set; } // id ������

        [ForeignKey(nameof(ticket_id))]
        public virtual Tickets Ticket { get; set; }//

    }
}