using Labwork5.Application.Models.Operations;

namespace Labwork5.Application.Contracts.Operations;

public interface IOperationsService
{
    IEnumerable<Operation> GetOperationsHistory();
}