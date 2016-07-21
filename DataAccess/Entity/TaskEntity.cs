namespace DataAccess.Entity
{
    public class TaskEntity : BaseEntity
    {
        public int CreatorId { get; set; }
        public int ResponsibleUsers { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
    }
}
