namespace SpecificationPattern.Specifications.Base
{
    public static class ExtensionMethods
    {
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> firstSpecification, ISpecification<TEntity> secondSpecification)
        {
            return new AndSpecification<TEntity>(firstSpecification, secondSpecification);
        }

        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> firstSpecification, ISpecification<TEntity> secondSpecification)
        {
            return new OrSpecification<TEntity>(firstSpecification, secondSpecification);
        }

        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }
    }
}
