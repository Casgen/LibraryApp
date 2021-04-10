using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Publisher
{
    [ExtendObjectType(Name = "RootQuery")]
    public class PublisherQueries
    {
        private readonly PublisherRepository publisherRepository;

        public PublisherQueries(PublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        public async Task<PublisherModel> GetPublisher(int id)
        {
            PublisherModel publisher = await publisherRepository.GetByIdAsync(id);
            return publisher;
        }
        public async Task<List<PublisherModel>> GetPublishers()
        {
            List<PublisherModel> publishers = (List<PublisherModel>) await publisherRepository.GetAllAsync();
            return publishers;
        }
    }
}
