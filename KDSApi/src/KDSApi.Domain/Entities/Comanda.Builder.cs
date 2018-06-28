using KDSApi.Domain.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Builder;
using Tnf.Notifications;

namespace KDSApi.Domain.Entities
{
    public partial class Comanda
    {
        public class Builder : Builder<Comanda>
        {
            public Builder(INotificationHandler notificationHandler)
                : base(notificationHandler)
            {
            }

            public Builder(INotificationHandler notificationHandler, Comanda instance)
                : base(notificationHandler, instance)
            {
            }

            public Builder WithIdComanda(int idComanda)
            {
                Instance.IdComanda = idComanda;
                return this;
            }

            public Builder WithNumeroComanda(string numeroComanda)
            {
                Instance.NumeroComanda = numeroComanda;
                return this;
            }

            protected override void Specifications()
            {
                AddSpecification<ComandaShouldHaveNameSpecification>();
            }
        }
    }
}
