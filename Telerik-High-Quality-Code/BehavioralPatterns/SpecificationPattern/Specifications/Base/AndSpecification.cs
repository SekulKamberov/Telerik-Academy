namespace SpecificationPattern.Specifications.Base
{
    using System;

    public class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> firstSpecification;
        private readonly ISpecification<TEntity> secondSpecification;

        public AndSpecification(ISpecification<TEntity> firstSpecification, ISpecification<TEntity> secondSpecification)
        {
            if (firstSpecification == null)
            {
                throw new ArgumentNullException("firstSpecification");
            }

            if (secondSpecification == null)
            {
                throw new ArgumentNullException("secondSpecification");
            }

            this.firstSpecification = firstSpecification;
            this.secondSpecification = secondSpecification;
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return this.firstSpecification.IsSatisfiedBy(candidate) && this.secondSpecification.IsSatisfiedBy(candidate);
        }
    }
}
