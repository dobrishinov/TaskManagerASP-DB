namespace DataAccess.Entity
{
    using System;

    public class TimeEntity : BaseEntity
    {
        public int TaskId { get; set; }
        public int EstimatedTime { get; set; }
        public DateTime LastChange { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
