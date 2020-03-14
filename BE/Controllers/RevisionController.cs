using System.Collections.Generic;
using System.Linq;
using BE.Queries.Revisions.GetAllRevisions;
using BE.Queries.Revisions.GetRevisionById;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    public class RevisionController
    {
        #region Ctor
        private readonly MyContext _context;
        public RevisionController(MyContext context)
        {
            _context = context;
        }
        #endregion

        #region Get
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
        #endregion
    }
}