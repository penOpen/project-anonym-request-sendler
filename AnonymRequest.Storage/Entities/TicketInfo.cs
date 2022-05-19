using System;
namespace AnonymRequest.Storage.Entities
{
    public class TicketInfo
    {
        [Key]
        public int Id { get; set; } //id жалобы

        public string name { get; set; }
        public string description { get; set; } //text

        public string status { get; set; }// status = 0 1 2


    }

}