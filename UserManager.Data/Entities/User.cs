namespace UserManager.Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;

        public IEnumerable<RoleUser> RoleUsers { get; set; } = null!;
        //public IEnumerable<Role> Roles { get; set; } = null!;
    }
}