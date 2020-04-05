using BE.BL.Clients.Cars;
using BE.BL.Clients.Revisions;
using BE.Queries.Clients;
using System;
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
            if (createClientCommand is null)
            {
                throw new ArgumentNullException(nameof(createClientCommand), "Input was null!");
            }
            var client = new ClientAggregate(createClientCommand.FirstName, createClientCommand.LastName, createClientCommand.PhoneNumber,
                                             createClientCommand.Email, createClientCommand.Password);
            return client;
        }

        public ClientAggregate Create(long clientId)
        {
            var clientResult = _clientsReadRepo.GetClient(clientId);
            if (clientResult is null)
            {
                throw new ArgumentException("No client with this id was found!");
            }
            var cars = _clientsReadRepo.GetClientCars(clientId).Select(c=>new Car(c.Id,c.ClientId,c.BrandName,
                                                                       c.ModelName,c.PlateNumber,c.RegistrationId)).ToList();
            if (cars is null)
            {
                throw new ArgumentException("No car for this client was found!");
            }
            var revisions = _clientsReadRepo.GetClientRevisions(clientId).Select(r=>new Revision(r.Id,r.ClientId,r.CarId,r.Title,r.ProblemDetails)).ToList();
            if (revisions is null)
            {
                throw new ArgumentException(nameof(revisions), "No revision for this client was found!");
            }
            var client = new ClientAggregate(clientResult.Id, clientResult.FirstName, clientResult.LastName,
                                             clientResult.PhoneNumber, clientResult.Email, clientResult.Password,
                                             cars,revisions);
                       
            return client;
        }
    }
}
