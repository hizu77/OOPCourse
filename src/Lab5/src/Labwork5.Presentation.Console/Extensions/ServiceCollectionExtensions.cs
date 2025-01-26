using Labwork5.Presentation.Console.Scenarios;
using Labwork5.Presentation.Console.Scenarios.BankAccountLogin.AdminLoginScenarios;
using Labwork5.Presentation.Console.Scenarios.BankAccountLogin.UserLoginScenarios;
using Labwork5.Presentation.Console.Scenarios.BankAccountLogout.AdminLogoutScenarios;
using Labwork5.Presentation.Console.Scenarios.BankAccountLogout.UserLogoutScenarios;
using Labwork5.Presentation.Console.Scenarios.ChangePassword;
using Labwork5.Presentation.Console.Scenarios.CreateAccount;
using Labwork5.Presentation.Console.Scenarios.Deposit;
using Labwork5.Presentation.Console.Scenarios.GetBalance;
using Labwork5.Presentation.Console.Scenarios.GetOperationHistory;
using Labwork5.Presentation.Console.Scenarios.Withdraw;
using Microsoft.Extensions.DependencyInjection;

namespace Labwork5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutAdminScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ChangePasswordScenarioProvider>();

        collection.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetOperationHistoryScenarioProvider>();

        return collection;
    }
}