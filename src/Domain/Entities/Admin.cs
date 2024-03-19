namespace Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string TagUser { get; set; }
        public CommonUser User { get; set; }
    }
}
