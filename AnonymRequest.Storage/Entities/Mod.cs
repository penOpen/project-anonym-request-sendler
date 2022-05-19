namespace AnonymRequest.Storage.Entities
{
    public class Mod
    {
        [Key]
        public int Id { get; set; }

        public string token { get; set; }
        public int avatar { get; set; } 
        
        public int id_type { get; set; }

        [ForeignKey(nameof(avatar))]
        public virtual Files Avatar { get; set; }
        [ForeignKey(nameof(id_type))]
        public virtual Types Type {get; set;}

    }
}