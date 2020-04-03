using System.Collections.Generic;
using BE.BL.Clients;
using BE.BL.Clients.Cars;
using BE.BL.Clients.Revisions;
using BE.Queries.Clients;
using BE.Queries.Clients.Cars;
using BE.Queries.Clients.Revisions;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController
    {
        private readonly IClientsReadRepository _clientReadRepository;
        private readonly IClientsWriteRepository _clientsWriteRepository;
        private readonly IClientAggregateFactory _clientAggregateFactory;

        public ClientsController(IClientsReadRepository clientsReadContext, IClientsWriteRepository clientsWriteRepository,
                                 IClientAggregateFactory clientAggregateFactory)
        {
            _clientReadRepository = clientsReadContext;
            _clientsWriteRepository = clientsWriteRepository;
            _clientAggregateFactory = clientAggregateFactory;
        }

        [HttpGet("{clientId}")]
        public GetClientResult GetClient(long clientId)
        {
            return _clientReadRepository.GetClient(clientId);
        }

        [HttpGet("{clientId}/cars/{carId}")]
        public GetCarResult GetCarById(long clientId,long carId)
        {
            return _clientReadRepository.GetClientCar(clientId, carId);
        } 

        [HttpGet("{clientId}/cars")]
        public List<GetAllCarsForClientResult> GetAllCarsByClientId(long clientId)
        {
            return _clientReadRepository.GetClientCars(clientId);
        }

        [HttpGet("{clientId}/revisions")]
        public List<GetRevisionsForClientResult> GetAllRevisionsByClientId(long clientId)
        {
            return _clientReadRepository.GetClientRevisions(clientId);
        }

        [HttpGet("{clientId}/revisions/{revisionId}")]
        public GetRevisionResult GetRevisionById(long clientId,long revisionId)
        {
            return _clientReadRepository.GetClientRevision(clientId, revisionId);
        }

        [HttpPost("cars")]
        public void AddCar([FromBody] CreateCarCommand carCreateCommand)
        {
            var client = _clientAggregateFactory.Create(carCreateCommand.ClientId);
            client.AddCar(carCreateCommand);
            _clientsWriteRepository.Save(client);
        }

        [HttpPost("revisions")]
        public void AddRevision([FromBody] CreateRevisionCommand revisionCreateCommand)
        {
            var client = _clientAggregateFactory.Create(revisionCreateCommand.ClientId);
            client.AddRevision(revisionCreateCommand);
            _clientsWriteRepository.Save(client);
        }

        [HttpPost]
        public void RegisterClient([FromBody] CreateClientCommand createClientCommand)
        {
            var client = _clientAggregateFactory.Create(createClientCommand);
            _clientsWriteRepository.Save(client);
        }


        [HttpPut]
        public void EditClient([FromBody] EditClientCommand editClientCommand)
        {
            var client = _clientAggregateFactory.Create(editClientCommand.Id);
            client.Edit(editClientCommand);
            _clientsWriteRepository.Save(client);
        }


        [HttpPut("cars")]
        public void EditCar([FromBody] EditCarCommand carEditByIdCommand)
        {
            var client = _clientAggregateFactory.Create(carEditByIdCommand.ClientId);
            client.EditCar(carEditByIdCommand);
            _clientsWriteRepository.Save(client);
        }

        [HttpPut("revisions")]
        public void EditRevision([FromBody] EditRevisionCommand revisionEditCommand)
        {
            var client = _clientAggregateFactory.Create(revisionEditCommand.ClientId);
            client.EditRevision(revisionEditCommand);
            _clientsWriteRepository.Save(client);
        }

        [HttpDelete("{clientId}")]
        public void DeleteClient(long clientId)
        {
            var client = _clientAggregateFactory.Create(clientId);
            client.Delete();
            _clientsWriteRepository.Save(client);
        }

        [HttpDelete("{clientId}/cars/{carId}")]
        public void DeleteCar(long clientId,long carId)
        {
            var client = _clientAggregateFactory.Create(clientId);
            client.DeleteCar(carId);
            _clientsWriteRepository.Save(client);
        }

        [HttpDelete("{clientId}/revisions/{revisionId}")]
        public void DeleteRevision(long clientId, long revisionId)
        {
            var client = _clientAggregateFactory.Create(clientId);
            client.DeleteRevision(revisionId);
            _clientsWriteRepository.Save(client);
        }
    }
}