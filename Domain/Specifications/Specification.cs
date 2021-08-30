using System;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public abstract class Specification<T>
    {
        public bool IsSatisfiedBy(T item)
        {
            return Predicate.Compile()(item);
        }

        protected abstract Expression<Func<T, bool>> Predicate { get; }

        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
        {
            return specification.Predicate;
        }       
    }
}
