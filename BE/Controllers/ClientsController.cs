using System.Collections.Generic;
using System.Linq;
using BE.BL.Cars.Create;
using BE.BL.Cars.Edit;
using BE.BL.Revisions.Create;
using BE.BL.Revisions.Edit;
using BE.Queries.Cars;
using BE.Queries.Revisions.GetAllRevisionsByClientId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController
    {

        #region Ctor
        private readonly MyContext _context;
        public ClientsController(MyContext context)
        {
            _context = context;
        }
        #endregion

        #region Get
        [HttpGet("{clientId}/{carId}")]
        public GetCarByIdResult GetCarById(long clientId,long carId)
        {
            
            return _context.Set<GetCarByIdResult>().FromSqlRaw("EXEC [dbo].[usp_GetCarById] {0},{1}", carId,clientId).ToList().FirstOrDefault();            
        } 

        [HttpGet("{clientId}/cars")]
        public List<GetAllCarsByClientIdResult> GetAllCarsByClientId(long clientId)
        {
            return _context.Set<GetAllCarsByClientIdResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllCarsByClientId] {0}",clientId).ToList();            
        }

        [HttpGet("{clientId}/revisions")]
        public List<GetAllRevisionsByClientIdResult> GetAllRevisionsByClientId(long clientId)
        {

            return _context.Set<GetAllRevisionsByClientIdResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllRevisionsByClientId] {0}", clientId).ToList();
        }

        #endregion

        #region Post
        [HttpPost("{clientId}")]
        public void AddCar(long clientId,[FromBody] CarCreateCommand carCreateCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_InsertCar] {0},{1},{2},{3},{4}", 
                                                clientId,carCreateCommand.BrandName,
                                                carCreateCommand.ModelName,carCreateCommand.PlateNumber,
                                                carCreateCommand.RegistrationId);
        }

        [HttpPost("{clientId}")]
        public void AddRevision(long clientId,[FromBody] RevisionCreateCommand revisionCreateCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_InsertRevision] {0}, {1}", revisionCreateCommand.ProblemDetails, revisionCreateCommand.CarId, clientId);
        }

        #endregion

        #region Put
        [HttpPut("{clientId}/{carId}")]
        public void EditCar(long clientId,long carId,[FromBody] CarEditByIdCommand carEditByIdCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditCarById] {0},{1},{2},{3},{4},{5}", carId,
                                                clientId,carEditByIdCommand.BrandName,
                                                carEditByIdCommand.ModelName,carEditByIdCommand.PlateNumber,
                                                carEditByIdCommand.RegistrationId);
        }

        [HttpPut("{clientId}/{revisionId}")]
        public void EditRevision(long clientId,long revisionId, [FromBody] RevisionEditByIdCommand revisionEditCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditRevisionById] {0}, {1}, {2}", revisionId,clientId, revisionEditCommand.ProblemDetails);
        }
        #endregion

        #region Delete
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
        #endregion
    }
}