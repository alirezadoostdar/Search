using Elastic.Clients.Elasticsearch;
using Microsoft.AspNetCore.Http.HttpResults;
using Search.Models;

namespace Search.Endpoints
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder SearchEndpoints(this IEndpointRouteBuilder endpoint)
        {
            var endpointGroup = endpoint.MapGroup("/Serach").WithTags("Serach");
            endpointGroup.MapGet("/SerachInName", SearchItemsByName);

            return endpoint;
        }

        static async Task<Results<Ok<IReadOnlyCollection<CatalogItemIndex>>, NotFound>> SearchItemsByName(string qr, ElasticsearchClient elasticsearch)
        {
            var response = await elasticsearch.SearchAsync<CatalogItemIndex>(s => s
                .Index(CatalogItemIndex.IndexName)
                .From(0)
                .Size(10)
                .Query(q =>
                     q.Fuzzy(t => t.Field(x => x.Name).Value(qr)))
            );

            if (response.IsValidResponse)
                return TypedResults.Ok(response.Documents);

            return TypedResults.NotFound();

        }
    }
}
