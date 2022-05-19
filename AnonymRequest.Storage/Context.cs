using AnonymRequest.Storage.Entities;

namespace AnonymRequest.Storage
{

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentFiles> CommentFiles { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Mod> Mods { get; set; }
        public DbSet<TicketFiles> TicketFiles { get; set; }

        public DbSet<TicketInfo> TicketInfos { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TicketToken> TicketTokens { get; set; }
        public DbSet<Types> Types { get; set; }

    }

}
