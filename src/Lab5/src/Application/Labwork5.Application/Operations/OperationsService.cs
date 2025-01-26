using Labwork5.Application.Abstrctions.Repositories;
using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Contracts.Operations;
using Labwork5.Application.Models.Operations;

namespace Labwork5.Application.Operations;

public class OperationsService : IOperationsService
{
    private readonly IOperationsRepository _operationsRepository;
    private readonly ICurrentBankAccountService _currentBankAccount;

    public OperationsService(
        IOperationsRepository operationsRepository,
        ICurrentBankAccountService currentBankAccount)
    {
        _operationsRepository = operationsRepository;
        _currentBankAccount = currentBankAccount;
    }

    public IEnumerable<Operation> GetOperationsHistory()
    {
        return _currentBankAccount.Account is null
            ? []
            : _operationsRepository.GetOperationsHistoryByInvoice(
              _currentBankAccount.Account.Invoice);
    }
}