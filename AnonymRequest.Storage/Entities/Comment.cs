namespace AnonymRequest.Storage.Entities
{
    public class Comment
    {
        int id;
        bool is_mod;
        string text;
        string time = DateTime.Now.ToString("Hh:mm:ss");
        [ForeignKey(nameof(id))]
    }
}