using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Publication
{
     [ExtendObjectType("MutationQuery")]
    public class PublicationMutations
    {
        private readonly PublicationRepository publicationRepository;

        public PublicationMutations(PublicationRepository publicationRepository)
        {
            this.publicationRepository = publicationRepository;
        }

        public async Task<PublicationModel> CreatePublication(PublicationModel publicationModel)
        {
            await publicationRepository.CreateAsync(publicationModel);
            return publicationModel;
        }

    }
}
