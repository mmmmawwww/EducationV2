namespace Training.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Training.DAL.Entities;

    public partial class TrainingContext : DbContext
    {
        public TrainingContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TestQuestions> TestQuestions { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tests>()
                .HasMany(e => e.TestQuestions)
                .WithOptional(e => e.Tests)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Topics>()
                .Property(e => e.Topic)
                .IsUnicode(false);

            modelBuilder.Entity<Topics>()
                .HasMany(e => e.Marks)
                .WithOptional(e => e.Topics)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Topics>()
                .HasOptional(e => e.Tests)
                .WithRequired(e => e.Topics)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Marks)
                .WithOptional(e => e.Users)
                .WillCascadeOnDelete();
        }
    }
}
