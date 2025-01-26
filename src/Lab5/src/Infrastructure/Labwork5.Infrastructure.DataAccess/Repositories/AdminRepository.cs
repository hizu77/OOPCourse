using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Labwork5.Application.Abstrctions.Repositories;
using Npgsql;

namespace Labwork5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public string GetSystemPassword()
    {
        const string sql = """
                           select password
                           from system_password
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.Read() is false
            ? string.Empty
            : reader.GetString(0);
    }

    public void ChangePassword(string newPassword)
    {
        const string sql = """
                           update system_password
                           set password = :newPassword;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("newPassword", newPassword);

        command.ExecuteNonQuery();
    }
}