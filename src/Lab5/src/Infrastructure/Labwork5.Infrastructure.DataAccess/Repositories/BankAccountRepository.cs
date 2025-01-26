using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Labwork5.Application.Abstrctions.Repositories;
using Labwork5.Application.Models.Accounts;
using Npgsql;

namespace Labwork5.Infrastructure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void AddInvoice(string number, string pin)
    {
        const string sql = """
                           insert into bank_accounts (invoice, pin, balance)
                           values (:number, :pin, :balance)
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("number", number)
            .AddParameter("pin", pin)
            .AddParameter("balance", 0);

        command.ExecuteNonQuery();
    }

    public BankAccount? FindAccountByInvoice(string number)
    {
        const string sql = """
                           select invoice, pin, balance
                           from bank_accounts
                           where invoice = :number;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("number", number);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.Read() is false
            ? null
            : new BankAccount(
                Invoice: reader.GetString(0),
                PinCode: reader.GetString(1),
                Balance: reader.GetDecimal(2));
    }

    public void ChangeAccountBalance(string number, decimal amount)
    {
        const string sql = """
                           update bank_accounts
                           set balance = :amount
                           where invoice = :number;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("amount", amount)
            .AddParameter("number", number);

        command.ExecuteNonQuery();
    }
}