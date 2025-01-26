using Labwork5.Application.Admins;
using Labwork5.Application.BankAccounts;
using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Contracts.Operations;
using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.AdminMode;
using Labwork5.Application.Contracts.Users.UserMode;
using Labwork5.Application.Operations;
using Labwork5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Labwork5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<IUserService, UserService>();

        collection.AddScoped<IOperationsService, OperationsService>();
        collection.AddScoped<IBankAccountService, BankAccountService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentBankAccountService>(
            p => p.GetRequiredService<CurrentAccountManager>());

        return collection;
    }
}