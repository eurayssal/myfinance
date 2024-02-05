using FinanceApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinanceApi.Services
{
    public class CadCategoriaService
    {
        private readonly IMongoCollection<CadCategoria> _cadCategoria;

        public CadCategoriaService(IOptions<FinanceDatabaseSettings> financeDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                financeDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                financeDatabaseSettings.Value.DatabaseName );

            _cadCategoria = mongoDatabase.GetCollection<CadCategoria>("cadcategoria");
        }

        public async Task<List<CadCategoria>> GetCategoriaAsync() =>
            await _cadCategoria.Find(x => true).ToListAsync();
        
        public async Task<CadCategoria?> GetCategoriaAsync(string id) =>
            await _cadCategoria.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateCategoriaAsync(CadCategoria newCategoria) =>
            await _cadCategoria.InsertOneAsync(newCategoria);

        public async Task UpdateCategoriaAsync(string id, CadCategoria updateCategoria) =>
            await _cadCategoria.ReplaceOneAsync(x => x.Id == id, updateCategoria);

        public async Task RemoveCategoriaAsync(string id) =>
            await _cadCategoria.DeleteOneAsync(x => x.Id == id);
    }
}
