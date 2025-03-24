namespace Repo_Inpatient_Care.GenericUtilitys
{
    public class ExcelData
    {
        private string password;
        private string email;
        private string role;
        private string username;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Role { get => role; set => role = value; }
    }
}