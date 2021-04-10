using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.User
{
    [ExtendObjectType("MutationQuery")]
    public class UserMutations
    {
        private readonly UserRepository userRepository;

        public UserMutations(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            await userRepository.CreateAsync(userModel);
            return userModel;
        }
    }
}
