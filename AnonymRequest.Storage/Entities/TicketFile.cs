using System.ComponentModel.DataAnnotations.Schema;
namespace AnonymRequest.Storage.Entities;
public class TicketFiles
{
    [Key]
    public int Id { get; set; } // id 


    int File_id { get; set; } // id файла
    int ticket_id { get; set; } // id жалобы

    [ForeignKey(nameof(File_id))]
    public virtual Files Files { get; set; }

    [ForeignKey(nameof(ticket_id))]
    public virtual Tickets Ticket { get; set; }//
}
