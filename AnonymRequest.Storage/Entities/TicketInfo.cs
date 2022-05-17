using System;
namespace AnonymRequest.Storage.Entities;

public class TicketInfo
{   
     int id;
     string name;
    string string_description;
    [ForeignKey(nameof(id))]
    [ForeignKey(nameof(name))]
}
