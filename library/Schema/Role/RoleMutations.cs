using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Role
{
    [ExtendObjectType("MutationQuery")]
    public class RoleMutations
    {
        private readonly RoleRepository roleRepository;

        public RoleMutations(RoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public async Task<RoleModel> CreateRole(RoleModel roleModel)
        {
            await roleRepository.CreateAsync(roleModel);
            return roleModel;
        }
    }
}
