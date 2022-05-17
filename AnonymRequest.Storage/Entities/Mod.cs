namespace AnonymRequest.Storage.Entities
{
    public class Mod
    {
        [Key]
        public int Id { get; set; }//id модера

        Guid token;// guid модера
        int avatar { get; set; } //ссылка на аватар (id файла)

        [ForeignKey(nameof(avatar))]
        public virtual Files Avatar { get; set; }

    }
}