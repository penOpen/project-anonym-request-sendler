namespace AnonymRequest.Storage.Entities
{
    public class Types
    {
        [Key]
        public int Id { get; set; } //id типа жалобы

        public string value { get; set; } // название типа
        public string description { get; set; } // описание
       
    }
}