using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Notifications;

namespace KDSApi.Domain.Entities
{
    public partial class Comanda : IEntity
    {

        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int IdComanda { get; set; }
        public string NumeroComanda { get; set; }
        

        public static Builder Create(INotificationHandler handler)
            => new Builder(handler);

        public static Builder Create(INotificationHandler handler, Comanda instance)
            => new Builder(handler, instance);
    }
}
