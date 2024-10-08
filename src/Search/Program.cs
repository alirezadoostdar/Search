using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Nodes;
using Elastic.Transport;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Search;
using Search.Endpoints;
using Search.Infrastructure.Extensions;
using Search.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.ElasticSearchConfigurs();
builder.BrokerConfigure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();



//app.MapGet("/", async (ElasticsearchClient client) =>
//{

//    var tweet = new Tweet()
//    {
//        Id = 1,
//        User = "stevejgordon",
//        PostDate = new DateTime(2009, 11, 15),
//        Message = "Trying out the client , so far so good?"
//    };
//    var response = await client.IndexAsync(tweet,index:"my-tweet-index");
//    if (response.IsValidResponse)
//    {
//        Console.WriteLine($"Index document with Id {response.Id} succeeded.");
//    }
//})
//WithOpenApi();
app.SearchEndpoints();
app.Run();



