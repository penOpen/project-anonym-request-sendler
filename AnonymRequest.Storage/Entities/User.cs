namespace AnonymRequest.Storage.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Token { get; set; }

}
