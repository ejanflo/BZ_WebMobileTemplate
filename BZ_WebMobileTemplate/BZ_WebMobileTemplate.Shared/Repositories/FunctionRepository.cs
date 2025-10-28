using BZ_WebMobileTemplate.Shared.Data;
using Microsoft.EntityFrameworkCore;
using BZ_WebMobileTemplate.Repositories.IRepository;

namespace BZ_WebMobileTemplate.Shared.Repositories
{
    public class FunctionRepository : IFunctionRepository
    {
        private readonly ApplicationDbContext _db;
        
        public FunctionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<UPRO_S_Function> CreateAsync(UPRO_S_Function obj)
        {
            await _db.Functions.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Functions.FindAsync(id);
            if (entity == null) return false;

            _db.Functions.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UPRO_S_Function>> GetAllAsync()
        {
            return await _db.Functions.ToListAsync();
        }

        public async Task<UPRO_S_Function> GetByIdAsync(int id)
        {
            return await _db.Functions
                .FirstOrDefaultAsync(f => f.FunctionId == id);
        }

        public async Task<UPRO_S_Function> UpdateAsync(UPRO_S_Function obj)
        {
            _db.Functions.Update(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
    }
}