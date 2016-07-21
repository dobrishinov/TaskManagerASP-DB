namespace WebTaskManager
{
    using DataAccess.Entity;
    using System.Data.Entity;

    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("TaskManagerDb")
        {
        }

        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<StatusEntity> Status { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TimeEntity> Time { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}