using System.ComponentModel.DataAnnotations;
namespace AnonymRequest.Storage.Entities;

public class Ticketguid
{
    [Key]
    public int Id { get; set; }
    Guid token { get; set; }
    int id { get; set; }
    [ForeignKey(nameof(id))]
    public virtual Tickets Tickets { get; set; }
}
