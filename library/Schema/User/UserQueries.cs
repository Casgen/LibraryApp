using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.User
{
    [ExtendObjectType(Name = "RootQuery")]
    public class UserQueries
    {
        private readonly UserRepository userRepository;

        public UserQueries(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<UserModel> GetUser(int id)
        {
            UserModel publisher = await userRepository.GetByIdAsync(id);
            return publisher;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            List<UserModel> publishers = (List<UserModel>)await userRepository.GetAllAsync();
            return publishers;
        }
    }
}
