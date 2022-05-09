using AnonymRequest.Storage.Entities;

namespace AnonymRequest.Storage;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Instantion> Instations { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Moderator> Moderators { get; set; }
}
