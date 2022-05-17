using System.ComponentModel.DataAnnotations;
namespace AnonymRequest.Storage.Entities;

public class Ticketguid
{    
    Guid token;
    int id;
    [ForeignKey(nameof(id))]
}
