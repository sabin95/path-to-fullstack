using System;

namespace BE.DAL
{
    public class Revision
    {
        public long Id { get; set; }
        public long CarId { get; set; }
        public string Title { get; set; }
        public string ProblemDetails { get; set; }        
        
    }
}
