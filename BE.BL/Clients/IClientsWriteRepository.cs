using BE.DAL;
using System.Collections.Generic;

namespace BE.BL.Clients
{
    public interface IClientsWriteRepository
    {
        void Save(ClientAggregate client);
        List<GetClientAggregateResult>  GetClientAggregate(long clientId);
    }
}