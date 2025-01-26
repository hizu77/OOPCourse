using Labwork5.Application.Abstrctions.Repositories;
using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Models.Operations;

namespace Labwork5.Application.BankAccounts;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IOperationsRepository _operationsRepository;
    private readonly CurrentAccountManager _currentBankAccount;

    public BankAccountService(
        IBankAccountRepository bankAccountRepository,
        IOperationsRepository operationsRepository,
        CurrentAccountManager currentBankAccount)
    {
        _bankAccountRepository = bankAccountRepository;
        _currentBankAccount = currentBankAccount;
        _operationsRepository = operationsRepository;
    }

    public DepositResult Deposit(decimal amount)
    {
        if (_currentBankAccount.Account is null)
        {
            return new DepositResult.UnauthorizedAccess();
        }

        if (amount < 0)
        {
            return new DepositResult.NegativeDepositAmount();
        }

        decimal newBalance = _currentBankAccount.Account.Balance + amount;
        string invoice = _currentBankAccount.Account.Invoice;

        _bankAccountRepository.ChangeAccountBalance(invoice, newBalance);

        _currentBankAccount.Account = _currentBankAccount.Account with
            { Balance = newBalance };

        _operationsRepository.SaveOperation(
            new Operation(
                invoice,
                OperationType.Deposit));

        return new DepositResult.Success();
    }

    public WithdrawResult Withdraw(decimal amount)
    {
        if (_currentBankAccount.Account is null)
        {
            return new WithdrawResult.UnauthorizedAccess();
        }

        if (amount < 0)
        {
            return new WithdrawResult.NegativeWithdrawAmount();
        }

        decimal newBalance = _currentBankAccount.Account.Balance - amount;

        if (newBalance < 0)
        {
            return new WithdrawResult.NotEnoughMoney();
        }

        string invoice = _currentBankAccount.Account.Invoice;

        _bankAccountRepository.ChangeAccountBalance(invoice, newBalance);

        _currentBankAccount.Account = _currentBankAccount.Account with
            { Balance = newBalance };

        _operationsRepository.SaveOperation(
            new Operation(
                invoice,
                OperationType.Withdraw));

        return new WithdrawResult.Success();
    }

    public decimal GetBalance()
    {
        if (_currentBankAccount.Account is null)
        {
            return 0;
        }

        _operationsRepository.SaveOperation(
            new Operation(
                _currentBankAccount.Account.Invoice,
                OperationType.BalanceCheck));

        return _currentBankAccount.Account.Balance;
    }
}