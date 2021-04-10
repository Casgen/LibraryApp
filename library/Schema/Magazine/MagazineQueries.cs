using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository;
using HotChocolate.Types;

namespace Library.Schema.Magazine
{
    [ExtendObjectType(Name = "RootQuery")]
    public class MagazineQueries
    {
        private readonly MagazineRepository magazineRepository;

        public MagazineQueries(MagazineRepository magazineRepository)
        {
            this.magazineRepository = magazineRepository;
        }

        public async Task<MagazineModel> GetMagazine(int id)
        {
            MagazineModel magazine = await magazineRepository.GetByIdAsync(id);
            return magazine;
        }

        public async Task<List<MagazineModel>> GetMagazines(List<String> urls)
        {
            List<MagazineModel> magazines = (List<MagazineModel>) await magazineRepository.GetAllAsync();
            return magazines;
        }
    }
}
