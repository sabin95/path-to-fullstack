using BE.Queries.Clients.Cars;
using BE.Queries.Clients.Revisions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE.Queries.Clients
{
    public class ClientsReadRepository : IClientsReadRepository
    {
        private readonly ReadGetYourCarFixedDbContext _readContext;

        public ClientsReadRepository(ReadGetYourCarFixedDbContext readContext)
        {
            _readContext = readContext;
        }
        public GetClientResult GetClient(long clientId)
        {
            return _readContext.Set<GetClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetClient] {0}", clientId).ToList().FirstOrDefault();
        }

        public GetCarResult GetClientCar(long clientId, long carId)
        {
            return _readContext.Set<GetCarResult>().FromSqlRaw("EXEC [dbo].[usp_GetCarById] {0},{1}", carId, clientId).ToList().FirstOrDefault();
        }

        public List<GetAllCarsForClientResult> GetClientCars(long clientId)
        {
            return _readContext.Set<GetAllCarsForClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllCarsByClientId] {0}", clientId).ToList();
        }

        public List<GetRevisionsForClientResult> GetClientRevisions(long clientId)
        {
            return _readContext.Set<GetRevisionsForClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllRevisionsByClientId] {0}", clientId).ToList();
        }

        public GetRevisionResult GetClientRevision(long clientId, long revisionId)
        {
            return _readContext.Set<GetRevisionResult>().FromSqlRaw("EXEC [dbo].[usp_GetRevision] {0},{1}", revisionId, clientId).ToList().FirstOrDefault();

        }


    }
}
