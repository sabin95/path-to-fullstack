using BE.BL.Clients.Cars;
using BE.BL.Clients.Revisions;
using BE.Queries.Clients;
using System.Linq;

namespace BE.BL.Clients
{
    public class ClientAggregateFactory : IClientAggregateFactory
    {
        private readonly IClientsReadRepository _clientsReadRepo;

        public ClientAggregateFactory(IClientsReadRepository clientsReadRepo)
        {
            _clientsReadRepo = clientsReadRepo;
        }

        public ClientAggregate Create(CreateClientCommand createClientCommand)
        {
            var client = new ClientAggregate(createClientCommand.FirstName, createClientCommand.LastName, createClientCommand.PhoneNumber,
                                             createClientCommand.Email, createClientCommand.Password);
            return client;
        }

        public ClientAggregate Create(long clientId)
        {
            var clientResult = _clientsReadRepo.GetClient(clientId);
            var cars = _clientsReadRepo.GetClientCars(clientId).Select(c=>new Car(c.Id,c.ClientId,c.BrandName,
                                                                       c.ModelName,c.PlateNumber,c.RegistrationId)).ToList();
            var revisions = _clientsReadRepo.GetClientRevisions(clientId).Select(r=>new Revision(r.Id,r.ClientId,r.CarId,r.Title,r.ProblemDetails)).ToList();
            var client = new ClientAggregate(clientResult.Id, clientResult.FirstName, clientResult.LastName,
                                             clientResult.PhoneNumber, clientResult.Email, clientResult.Password,
                                             cars,revisions);
                       
            return client;
        }
    }
}
