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

       
    }
}
