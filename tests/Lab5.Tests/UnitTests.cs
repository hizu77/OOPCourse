using Labwork5.Application.Abstrctions.Repositories;
using Labwork5.Application.BankAccounts;
using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Models.Accounts;
using Labwork5.Application.Models.Operations;
using NSubstitute;
using Xunit;

namespace Lab5.Tests;

public class UnitTests
{
    [Fact]
    public void Withdraw_ShouldReturnCorrectBalance_WhenBalanceGreaterThanWithdraw()
    {
        // Arrange
        IBankAccountRepository accountRepository = Substitute.For<IBankAccountRepository>();
        IOperationsRepository operationsRepository = Substitute.For<IOperationsRepository>();
        var currentAccount = new CurrentAccountManager
        {
            Account = new BankAccount("111", "111", 100),
        };

        var service = new BankAccountService(
            accountRepository,
            operationsRepository,
            currentAccount);

        // Act
        service.Withdraw(1);
        decimal balance = service.GetBalance();

        // Assert
        Assert.Equal(99, balance);
        Assert.Equal(99, currentAccount.Account.Balance);

        accountRepository.Received().ChangeAccountBalance("111", 99);
        operationsRepository.Received().SaveOperation(
            new Operation("111", OperationType.Withdraw));
    }

    [Fact]
    public void Withdraw_ShouldReturnFailed_WhenWithdrawGreaterThanBalance()
    {
        // Arrange
        IBankAccountRepository accountRepository = Substitute.For<IBankAccountRepository>();
        IOperationsRepository operationsRepository = Substitute.For<IOperationsRepository>();
        var currentAccount = new CurrentAccountManager
        {
            Account = new BankAccount("111", "111", 100),
        };

        var service = new BankAccountService(
            accountRepository,
            operationsRepository,
            currentAccount);

        // Act
        WithdrawResult result = service.Withdraw(111);

        // Assert
        Assert.IsType<WithdrawResult.NotEnoughMoney>(result);

        accountRepository.DidNotReceive().ChangeAccountBalance("111", Arg.Any<decimal>());
        operationsRepository.DidNotReceive().SaveOperation(
            new Operation("111", OperationType.Withdraw));
    }

    [Fact]
    public void Deposit_ShouldCorrectChangeAccountBalance_WhenCorrect()
    {
        // Arrange
        IBankAccountRepository accountRepository = Substitute.For<IBankAccountRepository>();
        IOperationsRepository operationsRepository = Substitute.For<IOperationsRepository>();
        var currentAccount = new CurrentAccountManager
        {
            Account = new BankAccount("111", "111", 0),
        };

        var service = new BankAccountService(
            accountRepository,
            operationsRepository,
            currentAccount);

        // Act
        service.Deposit(99);
        decimal balance = service.GetBalance();

        // Assert
        Assert.Equal(99, balance);
        Assert.Equal(99, currentAccount.Account.Balance);

        accountRepository.Received().ChangeAccountBalance("111", 99);
        operationsRepository.Received().SaveOperation(
            new Operation("111", OperationType.Deposit));
    }

    [Fact]
    public void Deposit_ShouldntChangeAccountBalance_WhenIncorrect()
    {
        // Arrange
        IBankAccountRepository accountRepository = Substitute.For<IBankAccountRepository>();
        IOperationsRepository operationsRepository = Substitute.For<IOperationsRepository>();
        var currentAccount = new CurrentAccountManager
        {
            Account = new BankAccount("111", "111", 0),
        };

        var service = new BankAccountService(
            accountRepository,
            operationsRepository,
            currentAccount);

        // Act
        DepositResult result = service.Deposit(-99);

        // Assert
        Assert.IsType<DepositResult.NegativeDepositAmount>(result);

        accountRepository.DidNotReceive().ChangeAccountBalance("111", Arg.Any<decimal>());
        operationsRepository.DidNotReceive().SaveOperation(
            new Operation("111", OperationType.Deposit));
    }
}