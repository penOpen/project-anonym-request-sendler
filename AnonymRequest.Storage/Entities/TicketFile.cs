using System.ComponentModel.DataAnnotations.Schema;
namespace AnonymRequest.Storage.Entities;

public class TicketFile
{
    [Key]
    int File_id;
    [Key]
    int ticket_id;
}
