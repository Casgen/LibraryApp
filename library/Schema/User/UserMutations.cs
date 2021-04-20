using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace Library.Schema.User
{
    public class UserMutations
    {
        public async Task<UserModel> Register(UserModel userModel, [ScopedService] LibraryDbContext context)
        {
            userModel.Password = getHash(userModel.Password);
            await context.Users.AddAsync(userModel);
            await context.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel> Login(string password, string userName, [ScopedService] LibraryDbContext context)
        {
            UserModel userModel = await context.Users.Where(x=>x.Username==userName).FirstOrDefaultAsync();
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
        public async Task<UserModel> DeleteUser(int id, [ScopedService] LibraryDbContext context)
        {
            UserModel userModel = await context.Users.FindAsync(id);
            context.Users.Remove(userModel);
            await context.SaveChangesAsync();
            return userModel;
        }
    }
}
