using Labwork5.Application.Models.Accounts;

namespace Labwork5.Application.Contracts.Accounts;

public interface ICurrentBankAccountService
{
    BankAccount? Account { get; }
}