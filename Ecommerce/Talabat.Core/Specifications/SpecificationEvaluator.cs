using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public static class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery, ISpecification<T> Spec)
        {
            var Query = InputQuery;
            if(Spec.Criteria is not null)
            {
                Query = Query.Where(Spec.Criteria);
            }
            Query = Spec.Includes.Aggregate(Query, (currentQuery, includeExpression) =>
            currentQuery.Include(includeExpression));

            return Query;
        }
    }
}
