using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tnf.Specifications;

namespace KDSApi.Domain.Entities.Specifications
{
    public class ComandaShouldHaveNameSpecification : Specification<Comanda>
    {
        public override string LocalizationSource { get; protected set; } = Constants.LocalizationSourceName;
        public override Enum LocalizationKey { get; protected set; } = Customer.Error.CustomerShouldHaveName;

        public override Expression<Func<Comanda, bool>> ToExpression()
        {
            return (p) => !string.IsNullOrWhiteSpace(p.NumeroComanda);
        }
    }
}
