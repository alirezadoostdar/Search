using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Options;

namespace Search.Infrastructure.Extensions
{
    public static class ElasticSearchDependencyInjection
    {
        public static void ElasticSearchConfigurs(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped(sp =>
              {
                  var elasticSetting = sp.GetRequiredService<IOptions<AppSettings>>().Value.ElasticSearchOptions;

                  var settings = new ElasticsearchClientSettings(new Uri(elasticSetting.Host))
                  .CertificateFingerprint(elasticSetting.Fingerprint)
                  .Authentication(new BasicAuthentication(elasticSetting.UserName, elasticSetting.Password));

                  return new ElasticsearchClient(settings);
              });
        }
    }
}
