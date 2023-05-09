using Desaprendiendo.Models;
using Desaprendiendo.Models.DomainModel;
using Desaprendiendo.Models.Validation.Interfaces;
using System.Linq;

namespace Desaprendiendo.Services.Repository
{
    public class BannerRepository : GenericRepository<Banner> , IBannerRepository
    {
        public BannerRepository(DBContextEF dbContext)
            : base(dbContext)
        {
        }
        public new IQueryable<Banner> GetAll()
        {
            return base.SpecificationFilter(new BannerImagenesSpecification()).AsQueryable();
            //return base.GetAll().Where(p => (p.ImagenMiniatura != null && p.ImagenGrande != null));
        }
    }
}
