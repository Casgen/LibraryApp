using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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

        public async Task<UserModel> Register(UserModel userModel)
        {
            userModel.Password = getHash(userModel.Password);
            await userRepository.CreateAsync(userModel);
            return userModel;
        }

        public async Task<UserModel> Login(string password, string userName)
        {
            UserModel userModel = await userRepository.GetByName(userName);
            string hashedPassword = getHash(password);
            if (!userModel.Password.Equals(hashedPassword)) return null;
            return userModel;
        }

        private string getHash(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(Encoding.UTF8.GetBytes(text.ToCharArray()));
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
