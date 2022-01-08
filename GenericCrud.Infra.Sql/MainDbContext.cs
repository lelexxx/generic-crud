using GenericCrud.Infra.Sql.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GenericCrud.Infra.Sql;

public class MainDbContext : DbContext
{
    private IOptions<SqlOption> SqlSettings { get; }

    public MainDbContext(IOptions<SqlOption> sqlSettings)
    {
        SqlSettings = sqlSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(SqlSettings.Value.ConnectionString, builder =>
        {
            builder.EnableRetryOnFailure(SqlSettings.Value.MaxRetryCount, TimeSpan.FromSeconds(SqlSettings.Value.MaxRetryDelay), null);
        });
    }
}