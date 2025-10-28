using BZ_WebMobileTemplate.Shared.Data;

namespace BZ_WebMobileTemplate.Repositories.IRepository
{
    public interface IFunctionRepository
    {
        public Task<UPRO_S_Function> CreateAsync(UPRO_S_Function obj);
        public Task<UPRO_S_Function> UpdateAsync(UPRO_S_Function obj);
        public Task<bool> DeleteAsync(int id);
        public Task<UPRO_S_Function> GetByIdAsync(int id);
        public Task<IEnumerable<UPRO_S_Function>> GetAllAsync();
    }
}