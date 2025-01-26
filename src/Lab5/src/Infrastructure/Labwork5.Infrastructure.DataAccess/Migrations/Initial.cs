using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Labwork5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type operation_type as enum
        (
            'withdraw',
            'deposit',
            'balance_check',
            'login',
            'create'
        );

        create table bank_accounts 
        (
            id bigint primary key generated always as identity,
            invoice text not null,
            pin text not null,
            balance decimal not null
        );

        create table operations_history
        (
            id bigint primary key generated always as identity,
            invoice text not null,
            type operation_type not null
        );

        create table system_password
        (
            id bigint primary key generated always as identity,
            password text not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table passwords_hashes;
        drop table operations_history;
        drop table bank_accounts;
        drop type operation_type;
        """;
}