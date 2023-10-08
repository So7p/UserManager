namespace UserManager.Business.DTOs.RoleUser
{
    public class RoleUserForViewDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public int UserAge { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserRoleName { get; set; } = null!;
    }
}