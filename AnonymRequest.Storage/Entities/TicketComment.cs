namespace AnonymRequest.Storage.Entities
{
    
    public class TicketComment
    {
        [Key]
        public int Id { get; set; }
        int ticket_id { get; set; } // id жалобы
        int comment_id { get; set; } // id коммента

        [ForeignKey(nameof(ticket_id))]
        public virtual Tickets Tickets { get; set; }

        [ForeignKey(nameof(comment_id))]
        public virtual Comment Comment { get; set; }

    }
}