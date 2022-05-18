using System.ComponentModel.DataAnnotations;
namespace AnonymRequest.Storage.Entities;

public class Ticketguid
{
    [Key]
    public int Id { get; set; }
    public Guid token { get; set; }

    public int id_ticket { get; set; }
    
    [ForeignKey(nameof(id_ticket))]
    public virtual Tickets Tickets { get; set; }//
}
