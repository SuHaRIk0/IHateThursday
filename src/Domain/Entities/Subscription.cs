namespace Domain.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public CommonUser Follower { get; set; }
        public int UserToId { get; set; }
    }
}
