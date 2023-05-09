using System;
using System.Linq.Expressions;
using Desaprendiendo.Models.DomainModel;

namespace Desaprendiendo.Models.Validation.Interfaces
{
    public class BannerImagenesSpecification : ISpecification<Banner>
    {

        public Expression<Func<Banner, bool>> IsSatisifiedBy()
        {
            return x => x.Id != null;
        }
    }
}
