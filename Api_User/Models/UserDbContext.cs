using Microsoft.EntityFrameworkCore;

namespace Api_User.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { }

        public DbSet<PersonalDancer> PersonalDancer { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FirebaseUserToken> FirebaseUserTokens { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PersonalDanceStyle>()
                .HasKey(pds => new { pds.PersonalDancerId, pds.StyleId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
