using FluentMigrator;

namespace AppDelivery.Infrastructure.Migrations.Versions;
[Migration(DatabaseVersions.TABLE_USER, "Criando tabela para salvar e pegar dados de usuários")]
    public class Version0000001 : VersionBase
{
        public override void Up()
        {
            CreateTable("Users")
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Password").AsString(2000).NotNullable();
        }
    }

