using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Magazine
{
    [ExtendObjectType("MutationQuery")]
    public class MagazineMutations
    {
        private readonly MagazineRepository magazineRepository;

        public MagazineMutations(MagazineRepository magazineRepository)
        {
            this.magazineRepository = magazineRepository;
        }

        public async Task<MagazineModel> CreateMagazine(MagazineModel magazineModel)
        {
            await magazineRepository.CreateAsync(magazineModel);
            return magazineModel;
        }

        public async Task<MagazineModel> DeleteMagazine(int id)
        {
            MagazineModel magazineModel = await magazineRepository.DeleteAsync(id);
            return magazineModel;
        }
    }
}
