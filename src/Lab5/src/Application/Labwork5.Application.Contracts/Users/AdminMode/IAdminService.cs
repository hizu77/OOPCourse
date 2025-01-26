using Labwork5.Application.Contracts.Accounts;

namespace Labwork5.Application.Contracts.Users.AdminMode;

public interface IAdminService
{
    CreateAccountResult AddAccount(string invoice, string pin);

    LoginResult Login(string password);

    void Logout();

    void ChangePassword(string newPassword);
}