using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema.Role
{
    [ExtendObjectType(Name = "RootQuery")]
    public class RoleQueries
    {
        private readonly RoleRepository roleRepository;

        public RoleQueries(RoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public async Task<RoleModel> GetRole(int id)
        {
            RoleModel publisher = await roleRepository.GetByIdAsync(id);
            return publisher;
        }
        public async Task<List<RoleModel>> GetRoles()
        {
            List<RoleModel> publishers = (List<RoleModel>)await roleRepository.GetAllAsync();
            return publishers;
        }
    }
}
