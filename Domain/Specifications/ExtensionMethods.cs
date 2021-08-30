namespace Domain.Specifications
{
    public static class ExtensionMethods
    {
        public static Specification<T> And<T>(this Specification<T> left, Specification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static Specification<T> Or<T>(this Specification<T> left, Specification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }
    }
}
