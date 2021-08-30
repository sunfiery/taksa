using System;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec1;
        private readonly Specification<T> _spec2;

        protected override Expression<Func<T, bool>> Predicate => ((Expression<Func<T, bool>>)_spec1).And(((Expression<Func<T, bool>>)_spec2));

        #region Ctor
        public AndSpecification(Specification<T> s1, Specification<T> s2)
        {
            _spec1 = s1;
            _spec2 = s2;
        }
        #endregion
    }
}
