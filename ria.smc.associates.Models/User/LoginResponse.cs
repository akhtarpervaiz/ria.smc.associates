namespace ria.smc.associates.UI.Models.Login
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int MessageCode { get; set; }
        public string Message { get; set; }
        public string? ProfilePicPath { get; set; }
        public bool ValidLogin { get; set; }
    }
}
