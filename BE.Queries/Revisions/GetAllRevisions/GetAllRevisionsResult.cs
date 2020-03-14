namespace BE.Queries.Revisions.GetAllRevisions
{
    public class GetAllRevisionsResult
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string ProblemDetails { get; set; } 
        public long CarId { get; set; }
    }
}
