namespace GenericCrud.Infra.Sql.Options;

public class SqlOption
{
    public static string Key => "Sql";
    public bool LoadFake { get; set; }
    public string ConnectionString { get; set; }
    public byte MaxRetryCount { get; set; }
    public byte MaxRetryDelay { get; set; }

    public SqlOption()
    {
        ConnectionString = string.Empty;
    }
}