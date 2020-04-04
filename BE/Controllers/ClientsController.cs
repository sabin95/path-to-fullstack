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
    public class ClientsController : Controller
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
        public IActionResult GetClient(long clientId)
        {
            if(clientId <0)
            {
                return BadRequest();
            }            
            return Ok(_clientReadRepository.GetClient(clientId));
        }

        [HttpGet("{clientId}/cars/{carId}")]
        public IActionResult GetCarById(long clientId,long carId)
        {
            if (clientId < 0 || carId<0)
            {
                return BadRequest();
            }            
            return Ok(_clientReadRepository.GetClientCar(clientId, carId));
        } 

        [HttpGet("{clientId}/cars")]
        public IActionResult GetAllCarsByClientId(long clientId)
        {
            if(clientId<0)
            {
                return BadRequest();
            }
            return Ok(_clientReadRepository.GetClientCars(clientId));
        }

        [HttpGet("{clientId}/revisions")]
        public IActionResult GetAllRevisionsByClientId(long clientId)
        {
            if (clientId < 0)
            {
                return BadRequest();
            }
            return Ok(_clientReadRepository.GetClientRevisions(clientId));
        }

        [HttpGet("{clientId}/revisions/{revisionId}")]
        public IActionResult GetRevisionById(long clientId,long revisionId)
        {
            if (clientId < 0 || revisionId<0)
            {
                return BadRequest();
            }
            return Ok(_clientReadRepository.GetClientRevision(clientId, revisionId));
        }

        [HttpPost("cars")]
        public IActionResult AddCar([FromBody] CreateCarCommand carCreateCommand)
        {
            if(carCreateCommand is null)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(carCreateCommand.ClientId);
            client.AddCar(carCreateCommand);
            _clientsWriteRepository.Save(client);
            return Ok();
        }

        [HttpPost("revisions")]
        public IActionResult AddRevision([FromBody] CreateRevisionCommand revisionCreateCommand)
        {
            if (revisionCreateCommand is null)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(revisionCreateCommand.ClientId);
            client.AddRevision(revisionCreateCommand);
            _clientsWriteRepository.Save(client);
            return Ok();
        }

        [HttpPost]
        public IActionResult RegisterClient([FromBody] CreateClientCommand createClientCommand)
        {
            if (createClientCommand is null)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(createClientCommand);
            _clientsWriteRepository.Save(client);
            return Ok();
        }


        [HttpPut]
        public IActionResult EditClient([FromBody] EditClientCommand editClientCommand)
        {
            if (editClientCommand is null)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(editClientCommand.Id);
            client.Edit(editClientCommand);
            _clientsWriteRepository.Save(client);
            return Ok();
        }


        [HttpPut("cars")]
        public IActionResult EditCar([FromBody] EditCarCommand carEditByIdCommand)
        {
            if (carEditByIdCommand is null)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(carEditByIdCommand.ClientId);
            client.EditCar(carEditByIdCommand);
            _clientsWriteRepository.Save(client);
            return Ok();
        }

        [HttpPut("revisions")]
        public IActionResult EditRevision([FromBody] EditRevisionCommand revisionEditCommand)
        {
            if (revisionEditCommand is null)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(revisionEditCommand.ClientId);
            client.EditRevision(revisionEditCommand);
            _clientsWriteRepository.Save(client);
            return Ok();
        }

        [HttpDelete("{clientId}")]
        public IActionResult DeleteClient(long clientId)
        {
            if (clientId <0)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(clientId);
            client.Delete();
            _clientsWriteRepository.Save(client);
            return Ok();
        }

        [HttpDelete("{clientId}/cars/{carId}")]
        public IActionResult DeleteCar(long clientId,long carId)
        {
            if (clientId < 0 || carId<0)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(clientId);
            client.DeleteCar(carId);
            _clientsWriteRepository.Save(client);
            return Ok();
        }

        [HttpDelete("{clientId}/revisions/{revisionId}")]
        public IActionResult DeleteRevision(long clientId, long revisionId)
        {
            if (clientId < 0 || revisionId < 0)
            {
                return BadRequest();
            }
            var client = _clientAggregateFactory.Create(clientId);
            client.DeleteRevision(revisionId);
            _clientsWriteRepository.Save(client);
            return Ok();
        }
    }
}