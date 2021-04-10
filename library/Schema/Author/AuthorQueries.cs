using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Author
{
    [ExtendObjectType(Name = "RootQuery")]
    public class AuthorQueries
    {
        private readonly AuthorRepository authorRepository;

        public AuthorQueries(AuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<AuthorModel> GetAuthor(int id)
        {
            AuthorModel author = await authorRepository.GetByIdAsync(id);
            return author;
        }

        public async Task<List<AuthorModel>> GetAuthors(List<String> urls)
        {
            List<AuthorModel> authors = (List<AuthorModel>) await authorRepository.GetAllAsync();
            return authors;
        }
    }
}
