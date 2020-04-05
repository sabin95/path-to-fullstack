using System;
using BE.BL.Clients;
using BE.BL.Clients.Cars;
using BE.BL.Clients.Revisions;
using BE.Queries.Clients;
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
            try
            {
                var client = _clientReadRepository.GetClient(clientId);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }

        [HttpGet("{clientId}/cars/{carId}")]
        public IActionResult GetClientCar(long clientId,long carId)
        {
            try
            {
                var clientCar = _clientReadRepository.GetClientCar(clientId, carId);
                return Ok(clientCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpGet("{clientId}/cars")]
        public IActionResult GetClientCars(long clientId)
        {
            try
            {
                var clientCars = _clientReadRepository.GetClientCars(clientId);
                return Ok(clientCars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{clientId}/revisions")]
        public IActionResult GetClientRevisions(long clientId)
        {
            try
            {
                var clientRevisions = _clientReadRepository.GetClientRevisions(clientId);
                return Ok(clientRevisions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{clientId}/revisions/{revisionId}")]
        public IActionResult GetClientRevision(long clientId,long revisionId)
        {
            try
            {
                var clientRevision = _clientReadRepository.GetClientRevision(clientId, revisionId);
                return Ok(clientRevision);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cars")]
        public IActionResult AddCar([FromBody] CreateCarCommand carCreateCommand)
        {
            try
            {
                var client = _clientAggregateFactory.Create(carCreateCommand.ClientId);
                client.AddCar(carCreateCommand);
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("revisions")]
        public IActionResult AddRevision([FromBody] CreateRevisionCommand revisionCreateCommand)
        {
            try
            {
                var client = _clientAggregateFactory.Create(revisionCreateCommand.ClientId);
                client.AddRevision(revisionCreateCommand);
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RegisterClient([FromBody] CreateClientCommand createClientCommand)
        {
            try
            {
                var client = _clientAggregateFactory.Create(createClientCommand);
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult EditClient([FromBody] EditClientCommand editClientCommand)
        {
            try
            {
                var client = _clientAggregateFactory.Create(editClientCommand.Id);
                client.Edit(editClientCommand);
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("cars")]
        public IActionResult EditCar([FromBody] EditCarCommand carEditByIdCommand)
        {
            try
            {
                var client = _clientAggregateFactory.Create(carEditByIdCommand.ClientId);
                client.EditCar(carEditByIdCommand);
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("revisions")]
        public IActionResult EditRevision([FromBody] EditRevisionCommand revisionEditCommand)
        {
            try
            {
                var client = _clientAggregateFactory.Create(revisionEditCommand.ClientId);
                client.EditRevision(revisionEditCommand);
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{clientId}")]
        public IActionResult DeleteClient(long clientId)
        {
            try
            {
                var client = _clientAggregateFactory.Create(clientId);
                client.Delete();
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{clientId}/cars/{carId}")]
        public IActionResult DeleteCar(long clientId,long carId)
        {
            try
            {
                var client = _clientAggregateFactory.Create(clientId);
                client.DeleteCar(carId);
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{clientId}/revisions/{revisionId}")]
        public IActionResult DeleteRevision(long clientId, long revisionId)
        {
            try
            {
                var client = _clientAggregateFactory.Create(clientId);
                client.DeleteRevision(revisionId);
                _clientsWriteRepository.Save(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}