namespace KImplementor.Utils
{
    public class LoginResponse
    {
        public string AccessToken { get; }
        public string Email { get; }

        public LoginResponse(string accessToken, string email)
        {
            AccessToken = accessToken;
            Email = email;
        }
    }
}
