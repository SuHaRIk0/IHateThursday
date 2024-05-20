using Domain.Entities;

namespace Web.Models
{
    public class FindNewFriendViewModel
    {
        public int CurrentUserId { get; set; }
        public string Tag { get; set; }
        public CommonUser FoundUser { get; set; }
    }
}