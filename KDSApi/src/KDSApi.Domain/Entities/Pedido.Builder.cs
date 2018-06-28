using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Builder;
using Tnf.Notifications;

namespace KDSApi.Domain.Entities
{
    public partial class Pedido
    {
        public class Builder : Builder<Pedido>
        {
            public Builder(INotificationHandler notificationHandler)
                : base(notificationHandler)
            {
            }

            public Builder(INotificationHandler notificationHandler, Pedido instance)
                : base(notificationHandler, instance)
            {
            }

            public Builder WithIdPedido(int idPedido)
            {
                Instance.IdPedido = idPedido;
                return this;
            }

            public Builder WithIdComanda(int idComanda)
            {
                Instance.IdComanda = idComanda;
                return this;
            }

            public Builder WithCanalAtendimento(string canalAtendimento)
            {
                Instance.CanalAtendimento = canalAtendimento;
                return this;
            }

            public Builder WithCodigoPedido(int codigoPedido)
            {
                Instance.CodigoPedido = codigoPedido;
                return this;
            }

            public Builder WithStatusAtualPedido(string statusAtualPedido)
            {
                Instance.StatusAtualPedido = statusAtualPedido;
                return this;
            }

            public Builder WithCodigoStatusAtualPedido(int codigoStatusAtualPedido)
            {
                Instance.CodigoStatusAtualPedido = codigoStatusAtualPedido;
                return this;
            }

            public Builder WithDataHoraInclusao(DateTime dataHoraInclusao)
            {
                Instance.DataHoraInclusao = dataHoraInclusao;
                return this;
            }

            //protected override void Specifications()
            //{
            //    AddSpecification<ComandaShouldHaveNameSpecification>();
            //}
        }
    }
}
