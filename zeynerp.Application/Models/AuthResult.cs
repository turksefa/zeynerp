namespace zeynerp.Application.Models
{
    public class AuthResult
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public static AuthResult Success() => new()
        {
            Succeeded = true
        };

        public static AuthResult Failed(List<string> errors) => new()
        {
            Succeeded = false,
            Errors = errors
        };
    }
}