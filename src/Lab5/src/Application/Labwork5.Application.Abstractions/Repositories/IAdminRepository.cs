namespace Labwork5.Application.Abstrctions.Repositories;

public interface IAdminRepository
{
    string GetSystemPassword();

    void ChangePassword(string newPassword);
}