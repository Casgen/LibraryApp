using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Author
{
    [ExtendObjectType("MutationQuery")]
    public class AuthorMutations
    {
        private readonly AuthorRepository authorRepository;

        public AuthorMutations(AuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<AuthorModel> CreateAuthor(AuthorModel authorModel)
        {
            await authorRepository.CreateAsync(authorModel);
            return authorModel;
        }

        public async Task<AuthorModel> DeleteAuthor(int id)
        {
            AuthorModel authorModel = await authorRepository.DeleteAsync(id);
            return authorModel;
        }
    }
}
