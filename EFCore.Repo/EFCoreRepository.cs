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
        private readonly HeroiContexto _contexto;

        public EFCoreRepository(HeroiContexto contexto)
        {
            _contexto = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _contexto.Update(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            //pelo retorno ser booleano, ele espera o retorno através do await, e por fim compara se é maior que 0 (lógica binária de 0 e 1/False and True)
            return ( await _contexto.SaveChangesAsync()) > 0 ;

        }

        public async Task<Heroi[]> GetAllHerois()
        {
            IQueryable<Heroi> query = _contexto.Herois
                .Include(h => h.Identidade)
                .Include(h => h.Armas);

            query = query.Include(h => h.HeroisBatalhas)
                 .ThenInclude(hb => hb.Batalha);

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public Task<Heroi[]> GetHeroiById()
        {
            throw new NotImplementedException();
        }

        public Task<Heroi> GetHeroiByNome()
        {
            throw new NotImplementedException();
        }
    }
}
