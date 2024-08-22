namespace Search
{
    public class AppSettings
    {
        public required ElasticSearchOptions ElasticSearchOptions { get; set; }
    }
    public sealed class ElasticSearchOptions
    {
        public required string Host { get; set; }
        public required string Fingerprint { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }

    public record BrokerOptions
    {
        public const string SectionName = "BrokerOptions";
        public required string Host { get; init; }
        public required string UserName { get; init; }
        public required string Password { get; init; }
    }
}
