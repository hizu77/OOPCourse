using Labwork5.Application.Models.Users;

namespace Labwork5.Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}