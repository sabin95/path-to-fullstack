using BE.BL.Clients.Cars;
using BE.BL.Clients.Revisions;
using BE.Queries.Clients;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BE.BL.Clients
{
    public class ClientAggregateFactory : IClientAggregateFactory
    {
        private readonly IClientsWriteRepository _clientsWriteRepository;

        public ClientAggregateFactory(IClientsWriteRepository clientsWriteRepository)
        {
            _clientsWriteRepository = clientsWriteRepository;
        }

        public ClientAggregate Create(CreateClientCommand createClientCommand)
        {
            if (createClientCommand is null || string.IsNullOrWhiteSpace(createClientCommand.LastName))
            {
                throw new ArgumentNullException(nameof(createClientCommand), "Input was null!");
            }
            var client = new ClientAggregate(createClientCommand.FirstName, createClientCommand.LastName, createClientCommand.PhoneNumber,
                                             createClientCommand.Email, createClientCommand.Password);
            return client;
        }

        public ClientAggregate Create(long clientId)
        {
            var clientAggregateResult = _clientsWriteRepository.GetClientAggregate(clientId);
            var clientResult = clientAggregateResult.FirstOrDefault();
            if (clientResult is null)
            {
                throw new ArgumentException("No client with this id was found!");
            }
            var cars = clientAggregateResult.ToList()
                                        .GroupBy(x => x.CarId)
                                        .Select(b => b.FirstOrDefault())
                                        .Where(d => d.CarId != null)
                                        .Select(c => new Car(c.ClientId.Value, c.ClientId.Value, c.BrandName, c.ModelName, c.PlateNumber, c.RegistrationId))
                                        .ToList();
            if (cars is null)
            {
                throw new ArgumentException("No car for this client was found!");
            }
            var revisions = clientAggregateResult.ToList()
                            .Where(x=>x.RevisionId != null)
                            .Select(r => new Revision(r.RevisionId.Value, r.ClientId.Value, r.CarId.Value, r.Title, r.ProblemDetails))
                            .ToList();
            if (revisions is null)
            {
                throw new ArgumentException(nameof(revisions), "No revision for this client was found!");
            }
            var client = new ClientAggregate(clientResult.ClientId.Value, clientResult.FirstName, clientResult.LastName,
                                             clientResult.PhoneNumber, clientResult.Email, clientResult.Password,
                                             cars, revisions);

            return client;
        }
    }
}
