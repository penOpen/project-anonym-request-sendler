namespace AnonymRequest.Storage.Entities;

public class Request
{
    [Key]
    public int Id { get; set; }
    public int InstationId { get; set; }

    [Required]
    public string Text { get; set; }
    public string Instation { get; set; }
    public int UserToken { get; set; }

    [ForeignKey(nameof(UserToken))]
    public virtual User User { get; set; }

}
