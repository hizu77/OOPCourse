using Labwork5.Application.Abstrctions.Repositories;
using Labwork5.Application.BankAccounts;
using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.UserMode;
using Labwork5.Application.Models.Accounts;
using Labwork5.Application.Models.Operations;
using Labwork5.Application.Models.Users;

namespace Labwork5.Application.Users;

public class UserService : IUserService
{
    private readonly CurrentUserManager _currentUser;
    private readonly CurrentAccountManager _currentBankAccount;
    private readonly IOperationsRepository _operationsRepository;
    private readonly IBankAccountRepository _bankAccountRepository;

    public UserService(
        CurrentUserManager currentUser,
        CurrentAccountManager currentBankAccount,
        IOperationsRepository operationsRepository,
        IBankAccountRepository bankAccountRepository)
    {
        _currentUser = currentUser;
        _currentBankAccount = currentBankAccount;
        _operationsRepository = operationsRepository;
        _bankAccountRepository = bankAccountRepository;
    }

    public LoginResult Login(string invoice, string pin)
    {
        BankAccount? bankAccount = _bankAccountRepository.FindAccountByInvoice(invoice);

        if (bankAccount is null ||
            bankAccount.PinCode != pin)
        {
            return new LoginResult.InvalidData();
        }

        _currentUser.User = new User(Mode.User);
        _currentBankAccount.Account = bankAccount;

        SaveOperation(
            invoice: _currentBankAccount.Account.Invoice,
            OperationType.Login);

        return new LoginResult.Success();
    }

    public void Logout()
    {
        _currentUser.User = null;
        _currentBankAccount.Account = null;
    }

    private void SaveOperation(
        string invoice,
        OperationType operationType)
    {
        _operationsRepository.SaveOperation(
            new Operation(
            invoice,
            operationType));
    }
}