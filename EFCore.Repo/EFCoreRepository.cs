using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroContext _context;

        public EFCoreRepository(HeroContext context)
        {
            _context = context;
        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Hero>> GetAllHeroes(bool includeBattles = false)
        {
            IQueryable<Hero> query = _context.Heroes
                .Include(h => h.Identity)
                .Include(h => h.Weapons);

            if (includeBattles) 
            { 
                query = query
                    .Include(h => h.HeroesBattles)
                    .ThenInclude(hb => hb.Battle);
            }

            query = query.OrderBy(h => h.Id);

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Hero> GetHeroById(int Id, bool includeBattles = false)
        {
            IQueryable<Hero> query = _context.Heroes
                .Include(h => h.Identity)
                .Include(h => h.Weapons);

            if (includeBattles)
            {
                query = query
                    .Include(h => h.HeroesBattles)
                    .ThenInclude(hb => hb.Battle);
            }

            query = query.OrderBy(h => h.Id);

            query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(h => h.Id == Id);
        }

        public async Task<IEnumerable<Hero>> GetHeroesByName(string Name, bool includeBattles = false)
        {
            IQueryable<Hero> query = _context.Heroes
                .Include(h => h.Identity)
                .Include(h => h.Weapons);

            if (includeBattles)
            {
                query = query
                    .Include(h => h.HeroesBattles)
                    .ThenInclude(hb => hb.Battle);
            }

            query = query
                .Where(h => h.Name.Contains(Name))
                .OrderBy(h => h.Id);

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Battle>> GetAllBattles(bool includeHeroes = false)
        {
            IQueryable<Battle> query = _context.Battles;

            if (includeHeroes)
            {
                query = query
                    .Include(b => b.HeroesBattles)
                    .ThenInclude(hb => hb.Hero);
            }

            query = query.OrderBy(b => b.Id);

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Battle> GetBattleById(int Id, bool includeHeroes = false)
        {
            IQueryable<Battle> query = _context.Battles;

            if (includeHeroes)
            {
                query = query
                    .Include(b => b.HeroesBattles)
                    .ThenInclude(hb => hb.Hero);
            }

            query = query.OrderBy(b => b.Id);

            query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(b => b.Id == Id);
        }
    }
}
