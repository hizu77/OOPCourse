using Labwork5.Application.Models.Accounts;

namespace Labwork5.Application.Abstrctions.Repositories;

public interface IBankAccountRepository
{
    void AddInvoice(string number, string pin);

    BankAccount? FindAccountByInvoice(string number);

    void ChangeAccountBalance(string number, decimal amount);
}