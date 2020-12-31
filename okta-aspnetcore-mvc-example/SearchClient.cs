using System;
using Microsoft.Extensions.Configuration;
using Nest;
using okta_aspnetcore_mvc_example.Models;

namespace okta_aspnetcore_mvc_example
{
    public class SearchClient : ISearchClient
    {
        private readonly ElasticClient client;

        public SearchClient(IConfiguration configuration)
        {
            client = new ElasticClient(
                new ConnectionSettings(new Uri(configuration.GetValue<string>("ElasticCloud:Endpoint")))
                    .DefaultIndex("kibana_sample_data_ecommerce")
                    .BasicAuthentication(configuration.GetValue<string>("ElasticCloud:BasicAuthUser"),
                        configuration.GetValue<string>("ElasticCloud:BasicAuthPassword")));
        }

        public ISearchResponse<Order> SearchOrder(string searchText)
        {
            return client.Search<Order>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.CustomerFullName)
                        .Query(searchText)
                    )
                ));
        }
    }

    public interface ISearchClient
    {
        ISearchResponse<Order> SearchOrder(string searchText);
    }
}