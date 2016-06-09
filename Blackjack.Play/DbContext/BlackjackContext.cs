namespace Blackjack.Play.DbContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlackjackContext : DbContext
    {
        public BlackjackContext()
            : base("name=BlackjackContext")
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Strategy> Strategies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(e => e.NetChanges)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Players)
                .WithMany(e => e.Games)
                .Map(m => m.ToTable("PlayerGames").MapLeftKey("Games_Id").MapRightKey("Players_ID"));

            modelBuilder.Entity<Player>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
