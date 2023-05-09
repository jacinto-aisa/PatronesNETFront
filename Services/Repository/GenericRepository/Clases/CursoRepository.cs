using System.Linq;
using Desaprendiendo.Models.DomainModel;

namespace Desaprendiendo.Services.Repository
{
    public class GenericRepository : GenericRepository<Curso> , ICursoRepository
    {
        public GenericRepository(DBContextEF dbContext)
            : base(dbContext)
        {
        }
        public new IQueryable<Curso> GetAll()
        {
            return base.GetAll().Where(x => x.Curso1.ToLower() != " no tocar");
        }

    }
}
