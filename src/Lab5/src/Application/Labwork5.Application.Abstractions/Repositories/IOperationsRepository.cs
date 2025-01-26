using Labwork5.Application.Models.Operations;

namespace Labwork5.Application.Abstrctions.Repositories;

public interface IOperationsRepository
{
    void SaveOperation(Operation operation);

    IEnumerable<Operation> GetOperationsHistoryByInvoice(string invoice);
}