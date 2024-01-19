namespace AuthApp.Domain.Services.Interfaces
{
    internal interface IPasswordHasherService
    {
        string HashPassword(string password, out byte[] salt);
        bool VerifyPassword(string password, string hash, byte[] salt);
    }
}
