using BE.Queries.Clients.Cars;
using BE.Queries.Clients.Revisions;
using System.Collections.Generic;

namespace BE.Queries.Clients
{
    public interface IClientsReadRepository
    {
        GetClientResult GetClient(long clientId);
        GetCarResult GetClientCar(long clientId, long carId);
        List<GetAllCarsForClientResult> GetClientCars(long clientId);
        GetRevisionResult GetClientRevision(long clientId, long revisionId);
        List<GetRevisionsForClientResult> GetClientRevisions(long clientId);
    }
}