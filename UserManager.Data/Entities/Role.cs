namespace UserManager.Data.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; } = null!;

        public IEnumerable<User> Users { get; set; } = null!;   
    }
}