namespace SpecificationPattern.Specifications.Base
{
    using System;

    public class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> specification;

        public NotSpecification(ISpecification<TEntity> specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException("specification");
            }

            this.specification = specification;
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return !this.specification.IsSatisfiedBy(candidate);
        }
    }
}
