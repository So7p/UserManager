namespace UserManager.Business.DTOs.User
{
    public class UserForViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
    }
}