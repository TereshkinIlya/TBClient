using Elastic.Clients.Elasticsearch;
using Core.Interfaces;

namespace Infrastructure.Data.Elasticsearch
{
    internal class ElasticContext : IDataContext<ElasticsearchClient>
    {
        public ElasticsearchClient DataBase => _client;

        private ElasticsearchClient _client;
        public ElasticContext()
        {
            var settings = new ElasticsearchClientSettings(new Uri("http://localhost:9200"));
            
            _client = new ElasticsearchClient(settings);
        }
    }
}
