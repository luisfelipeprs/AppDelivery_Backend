using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace AppDelivery.Infrastructure.Migrations.Versions;

public abstract class VersionBase : ForwardOnlyMigration
{
    protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string table)
    {
       return Create.Table(table)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("CreateOn").AsDateTime().NotNullable()
            .WithColumn("Active").AsBoolean().NotNullable();
    }
}

