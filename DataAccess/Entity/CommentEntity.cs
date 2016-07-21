namespace DataAccess.Entity
{
    using System;

    class CommentEntity : BaseEntity
    {
        public int CreatorId { get; set; }
        public int TaskId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
