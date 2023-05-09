using System.Linq;
using Desaprendiendo.Models.DomainModel;

namespace Desaprendiendo.Services.Repository
{
    public class SubCategoryRepository : GenericRepository<SubCategoria> , ISubCategoriaRepository
    {
        public SubCategoryRepository(DBContextEF dbContext)
            : base(dbContext)
        {
        }
        public new IQueryable<SubCategoria> GetAll()
        {
            return base.GetAll().Where(x => x.SubCategoria1.ToLower() != " no tocar");
        }

    }
}
