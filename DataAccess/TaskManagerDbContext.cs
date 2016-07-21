namespace DataAccess
{
    using System.Data.Entity;

    public class TaskManagerDb<T> : DbContext where T : class
    {
        public TaskManagerDb() : base("TaskManagerDb")
        {
        }

        public DbSet<T> Items { get; set; }

    }
}
