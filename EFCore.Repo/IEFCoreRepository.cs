using EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<IEnumerable<Hero>> GetAllHeroes(bool includeBattles = false);
        Task<Hero> GetHeroById(int Id, bool includeBattles = false);
        Task<IEnumerable<Hero>> GetHeroesByName(string Name, bool includeBattles = false);

        Task<IEnumerable<Battle>> GetAllBattles(bool includeHeroes = false);
        Task<Battle> GetBattleById(int Id, bool includeHeroes = false);
    }
}
