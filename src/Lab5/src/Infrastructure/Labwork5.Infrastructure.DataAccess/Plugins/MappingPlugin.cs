using Itmo.Dev.Platform.Postgres.Plugins;
using Labwork5.Application.Models.Operations;
using Labwork5.Application.Models.Users;
using Npgsql;

namespace Labwork5.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<Mode>();
        builder.MapEnum<OperationType>();
    }
}