namespace Portal.Entities
{
    public class Comment: BaseEntity
    {
        public string Text { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
        
        public long RequestId { get; set; }

        public Request Request { get; set; }
    }
}