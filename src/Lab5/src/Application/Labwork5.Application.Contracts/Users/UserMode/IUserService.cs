namespace Labwork5.Application.Contracts.Users.UserMode;

public interface IUserService
{
    LoginResult Login(string invoice, string pin);

    void Logout();
}