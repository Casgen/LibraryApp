using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Publisher
{
    [ExtendObjectType("MutationQuery")]
    public class PublisherMutations
    {
        private readonly PublisherRepository publisherRepository;

        public PublisherMutations(PublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }

        public async Task<PublisherModel> CreatePublisher(PublisherModel publisherModel)
        {
            await publisherRepository.CreateAsync(publisherModel);
            return publisherModel;
        }

        public async Task<PublisherModel> DeletePublisher(int id)
        {
            return await publisherRepository.DeleteAsync(id);
        }
    }
}
