using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BE.BL.Revisions.Create;
using BE.BL.Revisions.Edit;
using BE.Queries.Revisions.GetAllRevisions;
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
            var revisionList = new List<GetAllRevisionsResult>();
            revisionList = _context.Set<GetAllRevisionsResult>().FromSqlRaw("EXEC [dbo].[usp_GetAllRevisions]").ToList();            
            return revisionList;
        }

        [HttpGet("{revisionId}")]
        public GetRevisionByIdResult GetRevisionByIds(long revisionId)
        {
            
            return _context.Set<GetRevisionByIdResult>().FromSqlRaw("EXEC [dbo].[usp_GetRevisionById] {0}", revisionId).ToList().FirstOrDefault();            
        }

        [HttpPost]
        public void Add([FromBody] RevisionCreateCommand revisionCreateCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_InsertRevision] {0}", revisionCreateCommand.ProblemDetails);
        }

        [HttpPut("{revisionId}")]
        public void Edit(long revisionId, [FromBody] RevisionEditByIdCommand revisionEditCommand)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditRevisionById] {0}, {1}", revisionId, revisionEditCommand.ProblemDetails);
        }

        [HttpDelete("{revisionId}")]
        public void Delete(long revisionId)
        {
            _context.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteRevisionById] {0}", revisionId);
        }

    }
}