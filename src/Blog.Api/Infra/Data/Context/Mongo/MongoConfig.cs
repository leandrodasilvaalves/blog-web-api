namespace Blog.Api.Infra.Data.Context.Mongo;

public class MongoConfig
{
    public const string SectionName = "Mongo";
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
}