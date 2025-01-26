using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Models.Accounts;

namespace Labwork5.Application.BankAccounts;

public class CurrentAccountManager : ICurrentBankAccountService
{
    public BankAccount? Account { get; set; }
}