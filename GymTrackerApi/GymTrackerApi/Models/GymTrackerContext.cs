using Microsoft.EntityFrameworkCore;

namespace GymTrackerApi.Models
{
    public class GymTrackerContext : DbContext
    {
        public GymTrackerContext(DbContextOptions<GymTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<SessionHeader> SessionHeaders { get; set; }
        public DbSet<SessionExercise> SessionExercises { get; set; }
        public DbSet<SessionExerciseSet> SessionExerciseSets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<BodyPartType> BodyPartTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().ToTable("UserDetail");
            modelBuilder.Entity<SessionHeader>().ToTable("SessionHeader");
            modelBuilder.Entity<SessionExercise>().ToTable("SessionExercise");
            modelBuilder.Entity<SessionExerciseSet>().ToTable("SessionExerciseSet");
            modelBuilder.Entity<Exercise>().ToTable("Exercise");

        }
    }
}