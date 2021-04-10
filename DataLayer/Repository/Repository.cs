using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class Repository<T> where T : class
    {
        protected readonly LibraryDbContext libraryDbContext;

        public Repository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        //Read
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await libraryDbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await libraryDbContext.Set<T>().FindAsync(id);
        }
        //Create
        public async Task CreateAsync(T entity)
        {
            await libraryDbContext.Set<T>().AddAsync(entity);
            await libraryDbContext.SaveChangesAsync();
        }
        public async Task CreateManyAsync(List<T> entities)
        {
            libraryDbContext.Set<T>().AddRange(entities);
            await libraryDbContext.SaveChangesAsync();
        }
        //Patch
        public async Task UpdateAsync(T entity)
        {
            libraryDbContext.Entry(entity).State = EntityState.Modified;
            await libraryDbContext.SaveChangesAsync();
        }
        //Delete
        public async Task DeleteAsync(T entity)
        {
            libraryDbContext.Set<T>().Remove(entity);
            await libraryDbContext.SaveChangesAsync();
        }
        public async Task DeleteManyAsync(List<T> entity)
        {

            libraryDbContext.Set<T>().RemoveRange(entity);
            await libraryDbContext.SaveChangesAsync();
        }
    }
}
