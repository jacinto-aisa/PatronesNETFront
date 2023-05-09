using System;
using System.Linq.Expressions;
using Desaprendiendo.Models.DomainModel;

namespace Desaprendiendo.Models.Validation.Interfaces
{
    public class ClienteImagenesSpecification : ISpecification<Cliente>
    {

        public Expression<Func<Cliente, bool>> IsSatisifiedBy()
        {
            return x => x.Id != null;
        }
    }
}
