using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int UserToId { get; set; }


        public SubscriptionDTO(Subscription sub)
        {
            Id = sub.Id;
            FollowerId = sub.FollowerId;
            UserToId = sub.UserToId;
        }
    }

}