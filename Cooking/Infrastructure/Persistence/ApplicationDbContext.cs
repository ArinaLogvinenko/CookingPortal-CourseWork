namespace Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Domain.Entities;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipesFollowings> RecipesFollowings { get; set; }

        public DbSet<Message> Message { get; set; }

        public DbSet<UsersFollowings> UsersFollowings { get; set; }

        public DbSet<RecipeComment> RecipeComments { get; set; }

        //public DbSet<NotificationSettings> NotificationSettings { get; set; }

        //public DbSet<PersonalSettings> PersonalSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Followers).WithMany(x => x.Following).UsingEntity<UsersFollowings>(
                    j => j.HasOne(pt => pt.Followings).WithMany(t => t.UserFollowings).HasForeignKey(pt => pt.FollowingsId),
                    j => j.HasOne(pt => pt.Follower).WithMany().HasForeignKey(pt => pt.FollowerId),
                    j =>
                    {
                        j.HasKey(t => new { t.FollowerId, t.FollowingsId });
                        j.ToTable("UsersFollowings");
                    });
            modelBuilder.Entity<User>()
                .HasMany(x => x.Recipes).WithOne(x => x.Author);
            //modelBuilder.Entity<User>()
            //    .HasOne(x => x.NotificationSettings).WithOne(x => x.User).HasForeignKey<NotificationSettings>(pt => pt.UserId);
            //modelBuilder.Entity<User>()
            //    .HasOne(x => x.PersonalSettings).WithOne(x => x.User).HasForeignKey<PersonalSettings>(pt => pt.UserId);
            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.Followers).WithMany(x => x.SavedRecipes).UsingEntity<RecipesFollowings>(
                    j => j.HasOne(pt => pt.Follower).WithMany(t => t.RecipeFollowings).HasForeignKey(pt => pt.FollowerId),
                    j => j.HasOne(pt => pt.Recipe).WithMany(t => t.RecipeFollowings).HasForeignKey(pt => pt.RecipeId),
                    j =>
                    {
                        j.HasKey(t => new { t.FollowerId, t.RecipeId });
                        j.ToTable("RecipesFollowings");
                    });
            //modelBuilder.Entity<NotificationSettings>()
            //    .Property(x => x.PushNewFollowerNotify).HasDefaultValue(false);
            //modelBuilder.Entity<NotificationSettings>()
            //    .Property(x => x.PushNewMessageNotify).HasDefaultValue(false);
            //modelBuilder.Entity<NotificationSettings>()
            //    .Property(x => x.PushLikeNotify).HasDefaultValue(false);
            //modelBuilder.Entity<PersonalSettings>()
            //    .Property(x => x.FollowerSeeSavedRecipe).HasDefaultValue(false);
            //modelBuilder.Entity<PersonalSettings>()
            //    .Property(x => x.FollowerSeeFollowers).HasDefaultValue(false);

            modelBuilder.Entity<Message>()
                .HasOne<User>(a => a.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
