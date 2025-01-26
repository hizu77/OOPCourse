using Labwork5.Application.Abstrctions.Repositories;
using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.AdminMode;
using Labwork5.Application.Models.Operations;
using Labwork5.Application.Models.Users;
using Labwork5.Application.Users;

namespace Labwork5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly CurrentUserManager _currentUser;
    private readonly IAdminRepository _adminRepository;
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IOperationsRepository _operationsRepository;

    public AdminService(
        CurrentUserManager currentUser,
        IAdminRepository adminRepository,
        IBankAccountRepository bankAccountRepository,
        IOperationsRepository operationsRepository)
    {
        _currentUser = currentUser;
        _adminRepository = adminRepository;
        _bankAccountRepository = bankAccountRepository;
        _operationsRepository = operationsRepository;
    }

    public CreateAccountResult AddAccount(string invoice, string pin)
    {
        if (_bankAccountRepository.FindAccountByInvoice(invoice) is not null)
        {
            return new CreateAccountResult.AccountAlreadyExists();
        }

        _bankAccountRepository.AddInvoice(invoice, pin);

        _operationsRepository.SaveOperation(
            new Operation(
                invoice,
                OperationType.Create));

        return new CreateAccountResult.Success();
    }

    public LoginResult Login(string password)
    {
        string realPassword = _adminRepository.GetSystemPassword();

        if (password != realPassword)
        {
            return new LoginResult.InvalidData();
        }

        _currentUser.User = new User(Mode.Admin);

        return new LoginResult.Success();
    }

    public void Logout()
    {
        _currentUser.User = null;
    }

    public void ChangePassword(string newPassword)
    {
        _adminRepository.ChangePassword(newPassword);
    }
}