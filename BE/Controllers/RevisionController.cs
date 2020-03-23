using System.Collections.Generic;
using System.Linq;
using BE.BL.Revisions.Edit;
using BE.Queries.Revisions.GetAllRevisions;
using BE.Queries.Revisions.GetRevisionById;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    public class RevisionController
    {        
        private readonly GetYourCarFixedDbContext _context;
        public RevisionController(GetYourCarFixedDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<GetAllRevisionsResult> GetAllRevision()
        {
            return _context.Set<GetAllRevisionsResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllRevisions]").ToList();
        }

        [HttpGet("{revisionId}")]
        public GetRevisionResult GetRevisionById(long revisionId, long ClientId, long CarId)
        {

            return _context.Set<GetRevisionResult>().FromSqlRaw("EXEC [dbo].[usp_GetRevisionById] {0},{1},{2}", revisionId, ClientId, CarId).ToList().FirstOrDefault();
        }

        [HttpPut("{revisionId}")]
        public void EditRevision(long clientId, long revisionId, [FromBody] EditRevisionCommand revisionEditCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditRevisionById] {0}, {1}, {2},{3}", revisionId, clientId, revisionEditCommand.Title, revisionEditCommand.ProblemDetails);
        }
    }
}