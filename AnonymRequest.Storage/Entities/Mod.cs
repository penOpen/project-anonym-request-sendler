namespace AnonymRequest.Storage.Entities
{
    public class Mod
    {
        [Key]
        int id;
        string avatar;
        string tickets;
        string[] Id;
        [ForeignKey(nameof(id))]

        [ForeignKey(nameof(tickets))]

    }
}