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
            if (clientId <= 0)
            {
                throw new ArgumentNullException(nameof(clientId), "Invalid input!");
            }
            var client = _readContext.Set<GetClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetClient] {0}", clientId).ToList().FirstOrDefault();
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client), "No client found!");
            }
            return client;
        }

        public GetCarResult GetClientCar(long clientId, long carId)
        {
            if (clientId <= 0 || carId <= 0)
            {
                throw new ArgumentNullException(nameof(clientId), "Invalid input!");
            }
            var clientCar = _readContext.Set<GetCarResult>().FromSqlRaw("EXEC [dbo].[usp_GetCarById] {0},{1}", carId, clientId).ToList().FirstOrDefault();
            if (clientCar is null)
            {
                throw new ArgumentNullException(nameof(clientCar), "No car for this client was found!");
            }
            return clientCar;
        }

        public List<GetAllCarsForClientResult> GetClientCars(long clientId)
        {
            if (clientId <= 0)
            {
                throw new ArgumentNullException(nameof(clientId), "Invalid input!");
            }
            var clientCars = _readContext.Set<GetAllCarsForClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllCarsByClientId] {0}", clientId).ToList();
            if (clientCars is null)
            {
                throw new ArgumentNullException(nameof(clientCars), "No car for this client was found!");
            }
            return clientCars;
        }

        public List<GetRevisionsForClientResult> GetClientRevisions(long clientId)
        {
            if (clientId <= 0)
            {
                throw new ArgumentNullException(nameof(clientId), "Invalid input!");
            }
            var revision = _readContext.Set<GetRevisionsForClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllRevisionsByClientId] {0}", clientId).ToList();
            if (revision is null)
            {
                throw new ArgumentNullException(nameof(revision), "No revision for this client was found!");
            }
            return revision;
        }

        public GetRevisionResult GetClientRevision(long clientId, long revisionId)
        {
            if (clientId <= 0 || revisionId <= 0)
            {
                throw new ArgumentNullException(nameof(clientId), "Invalid input!");
            }
            var revisions = _readContext.Set<GetRevisionResult>().FromSqlRaw("EXEC [dbo].[usp_GetRevision] {0},{1}", revisionId, clientId).ToList().FirstOrDefault();
            if (revisions is null)
            {
                throw new ArgumentNullException(nameof(revisions), "No revision for this client was found!");
            }
            return revisions;
        }
    }
}
