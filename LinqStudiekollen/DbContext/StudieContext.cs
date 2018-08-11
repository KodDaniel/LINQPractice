using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen
{
    public class StudieContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }

        public StudieContext()
            : base("Name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Test>()
                .HasRequired(c => c.User);
                //.WithMany(a => a.Test)
                //.HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Question>()
                .HasRequired(c => c.Test)
                .WithMany(a => a.Question)
                .HasForeignKey(c => c.TestId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
