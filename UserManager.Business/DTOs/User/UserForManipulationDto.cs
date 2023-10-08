namespace UserManager.Business.DTOs.User
{
    public abstract class UserForManipulationDto
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
    }
}