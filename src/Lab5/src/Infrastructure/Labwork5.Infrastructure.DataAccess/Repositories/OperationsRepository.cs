using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Labwork5.Application.Abstrctions.Repositories;
using Labwork5.Application.Models.Operations;
using Npgsql;

namespace Labwork5.Infrastructure.DataAccess.Repositories;

public class OperationsRepository : IOperationsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void SaveOperation(Operation operation)
    {
        const string sql = """
                           insert into operations_history (invoice, type)
                           values (:number, :type)
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("number", operation.Invoice)
            .AddParameter("type", operation.OperationType);

        command.ExecuteNonQuery();
    }

    public IEnumerable<Operation> GetOperationsHistoryByInvoice(string invoice)
    {
        const string sql = """
                           select invoice, type
                           from operations_history
                           where invoice = :number;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("number", invoice);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Operation(
                Invoice: reader.GetString(0),
                OperationType: reader.GetFieldValue<OperationType>(1));
        }
    }
}