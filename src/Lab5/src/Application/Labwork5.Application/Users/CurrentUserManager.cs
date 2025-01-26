using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Models.Users;

namespace Labwork5.Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}