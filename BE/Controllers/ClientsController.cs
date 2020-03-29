using System.Collections.Generic;
using System.Linq;
using BE.BL.Cars.Create;
using BE.BL.Cars.Edit;
using BE.BL.Clients.Create;
using BE.BL.Clients.Edit;
using BE.BL.Revisions.Create;
using BE.Queries.Cars;
using BE.Queries.Clients.GetClientResult;
using BE.Queries.Revisions.GetAllRevisionsByClientId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController
    {
        private readonly GetYourCarFixedDbContext _context;
        public ClientsController(GetYourCarFixedDbContext context)
        {
            _context = context;
        }

        [HttpGet("{clientId}")]
        public GetClientResult GetClient(long clientId)
        {
            return _context.Set<GetClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetClient] {0}", clientId).ToList().FirstOrDefault();
        }

        [HttpGet("{clientId}/{carId}")]
        public GetCarResult GetCarById(long clientId,long carId)
        {
            
            return _context.Set<GetCarResult>().FromSqlRaw("EXEC [dbo].[usp_GetCarById] {0},{1}", carId,clientId).ToList().FirstOrDefault();            
        } 

        [HttpGet("{clientId}/cars")]
        public List<GetAllCarsForClientResult> GetAllCarsByClientId(long clientId)
        {
            return _context.Set<GetAllCarsForClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllCarsByClientId] {0}",clientId).ToList();            
        }

        [HttpGet("{clientId}/revisions")]
        public List<GetRevisionsForClientResult> GetAllRevisionsByClientId(long clientId)
        {

            return _context.Set<GetRevisionsForClientResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllRevisionsByClientId] {0}", clientId).ToList();
        }

        [HttpPost("{clientId}/cars")]
        public void AddCar(long clientId,[FromBody] CreateCarCommand carCreateCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_InsertCar] {0},{1},{2},{3},{4}", 
                                                clientId,carCreateCommand.BrandName,
                                                carCreateCommand.ModelName,carCreateCommand.PlateNumber,
                                                carCreateCommand.RegistrationId);
        }

        [HttpPost("{clientId}/revisions")]
        public void AddRevision([FromRoute] long clientId,[FromBody] CreateRevisionCommand revisionCreateCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_InsertRevision] {0}, {1},{2},{3}", revisionCreateCommand.Title, revisionCreateCommand.ProblemDetails, revisionCreateCommand.CarId, clientId);
        }

        [HttpPost]
        public void RegisterClient([FromBody] CreateClientCommand createClientCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_InsertClient] {0}, {1},{2},{3},{4}", createClientCommand.FirstName, createClientCommand.LastName, createClientCommand.PhoneNumber,
                                                                                    createClientCommand.Mail,createClientCommand.Password);
        }


        [HttpPut("{clientId}/{carId}")]
        public void EditCar(long clientId,long carId,[FromBody] EditCarCommand carEditByIdCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditCarById] {0},{1},{2},{3},{4},{5}", carId,
                                                clientId,carEditByIdCommand.BrandName,
                                                carEditByIdCommand.ModelName,carEditByIdCommand.PlateNumber,
                                                carEditByIdCommand.RegistrationId);
        }

        [HttpPut("{clientId}")]
        public void EditClient(long clientId,[FromBody] EditClientCommand editClientCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_Edit_Client] {0}, {1},{2},{3},{4},{5}", clientId,editClientCommand.FirstName, editClientCommand.LastName, editClientCommand.PhoneNumber,
                                                                                editClientCommand.Mail,editClientCommand.Password);
        }

        [HttpDelete("{clientId}")]
        public void DeleteClient(long clientId)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteClient] {0}", clientId);
        }

        [HttpDelete("{clientId}/{carId}")]
        public void DeleteCarById(long clientId,long carId)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteCarById] {0},{1}", carId,clientId);
        }

        [HttpDelete("{clientId}/cars")]
        public void DeleteCarByClientId(long clientId)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteCarsByClientId] {0}", clientId);
        }
    }
}