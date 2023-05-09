using Desaprendiendo.Models;
using Desaprendiendo.Models.DomainModel;
using Desaprendiendo.Models.Validation.Interfaces;
using System.Linq;

namespace Desaprendiendo.Services.Repository
{
    public class ClienteRepository : GenericRepository<Cliente> , IClienteRepository
    {
        public ClienteRepository(DBContextEF dbContext)
            : base(dbContext)
        {
        }
        public new IQueryable<Cliente> GetAll()
        {
            return base.SpecificationFilter(new ClienteImagenesSpecification()).AsQueryable();
            //return base.GetAll().Where(p => (p.ImagenMiniatura != null && p.ImagenGrande != null));
        }
    }
}
