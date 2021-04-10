using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Publication
{
    [ExtendObjectType(Name = "RootQuery")]
    public class PublicationQueries
    {
        private readonly PublicationRepository publicationRepository;

        public PublicationQueries(PublicationRepository publicationRepository)
        {
            this.publicationRepository = publicationRepository;
        }

        public async Task<PublicationModel> GetPublicaton(int id)
        {
            PublicationModel publication = await publicationRepository.GetByIdAsync(id);
            return publication;
        }

        public async Task<List<PublicationModel>> GetPublications(List<String> urls)
        {
            List<PublicationModel> publications = (List<PublicationModel>) await publicationRepository.GetAllAsync();
            return publications;
        }

    }
}
