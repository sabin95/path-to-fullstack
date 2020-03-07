using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BE.BL.Revisions.Create;
using BE.BL.Revisions.Edit;
using BE.Queries.Revisions.GetAllRevisions;
using BE.Queries.Revisions.GetAllRevisionsByClientId;
using BE.Queries.Revisions.GetRevisionById;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    public class RevisionController
    {
        private readonly MyContext _context;
        public RevisionController(MyContext context)
        {
            _context = context;
        }


        [HttpGet]
        public List<GetAllRevisionsResult> GetAllRevision()
        {            
            return _context.Set<GetAllRevisionsResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllRevisions]").ToList();            
        }

        [HttpGet("{revisionId}")]
        public GetRevisionByIdResult GetRevisionById(long revisionId)
        {
            
            return _context.Set<GetRevisionByIdResult>().FromSqlRaw("EXEC [dbo].[usp_GetRevisionById] {0}", revisionId).ToList().FirstOrDefault();            
        }

        [HttpGet("{clientId}")]
        public List<GetAllRevisionsByClientIdResult> GetAllRevisionsByClientId(long clientId)
        {
            
            return _context.Set<GetAllRevisionsByClientIdResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllRevisionsByClientId] {0}", clientId).ToList();            
        }

        [HttpPost]
        public void AddRevision([FromBody] RevisionCreateCommand revisionCreateCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_InsertRevision] {0}", revisionCreateCommand.ProblemDetails);
        }

        [HttpPut("{revisionId}")]
        public void EditRevision(long revisionId, [FromBody] RevisionEditByIdCommand revisionEditCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditRevisionById] {0}, {1}", revisionId, revisionEditCommand.ProblemDetails);
        }

        [HttpDelete("{revisionId}")]
        public void DeleteRevisionById(long revisionId)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteRevisionById] {0}", revisionId);
        }

        [HttpDelete("{clientId}")]
        public void DeleteRevisionsByClientId(long clientId)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteRevisionsByClientId] {0}", clientId);
        }

    }
}