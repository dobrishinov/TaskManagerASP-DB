namespace DataAccess.Entity
{
    public class StatusEntity : BaseEntity
    {
        public int TaskId { get; set; }
        public int CommentId { get; set; }
        public string Status { get; set; }
    }
}
