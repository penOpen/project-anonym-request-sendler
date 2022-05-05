namespace AnonymRequest.Storage.Entities;

public class Status
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Comment { get; set; }
    public bool? Condition { get; set; }
    public int RequestId { get; set; }

    [ForeignKey(nameof(RequestId))]
    public virtual Request Request { get; set; }

}
