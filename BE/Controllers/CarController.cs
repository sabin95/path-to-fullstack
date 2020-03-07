using System.Collections.Generic;
using System.Linq;
using BE.BL.Cars.Create;
using BE.Queries.Cars;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class CarsController
    {
        private readonly MyContext _context;
        public CarsController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("ClientId={clientId}")]
        public List<GetAllCarsByClientIdResult> GetAllCarsByClientId(int clientId)
        {
            return _context.Set<GetAllCarsByClientIdResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllCarsByClientId] {0}",clientId).ToList();            
        }

        [HttpGet("{carId}")]
        public GetCarByIdResult GetCarById(long carId)
        {
            
            return _context.Set<GetCarByIdResult>().FromSqlRaw("EXEC [dbo].[usp_GetRevisionById] {0}", carId).ToList().FirstOrDefault();            
        }

        [HttpPost]
        public void AddCar([FromBody] CarCreateCommand carCreateCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_InsertCar] {1},{2},{3},{4},{5}", 
                                                carCreateCommand.ClientId,carCreateCommand.BrandName,
                                                carCreateCommand.ModelName,carCreateCommand.PlateNumber,
                                                carCreateCommand.RegistrationId);
        }

        [HttpPut("{carId}")]
        public void EditCar(long carId,[FromBody] CarCreateCommand carEditByIdCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_UpdateCar] {1},{2},{3},{4},{5}", 
                                                carEditByIdCommand.ClientId,carEditByIdCommand.BrandName,
                                                carEditByIdCommand.ModelName,carEditByIdCommand.PlateNumber,
                                                carEditByIdCommand.RegistrationId);
        }

        [HttpDelete("{carId}")]
        public void DeleteCarById(long carId)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteCarById] {0}", carId);
        }

        [HttpDelete("ClientId={clientId}")]
        public void DeleteCarByClientId(long clientId)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteCarByClientId] {0}", clientId);
        }
    }
}