namespace UserManager.Business.DTOs.RoleUser
{
    public abstract class RoleUserForManipulationDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}