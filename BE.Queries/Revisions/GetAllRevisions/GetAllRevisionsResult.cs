namespace BE.Queries.Revisions.GetAllRevisions
{
    public class GetAllRevisionsResult
    {
        public long Id { get; set; }
        public int ClientId { get; set; }
        public string ProblemDetails { get; set; } 
        public BE.DAL.Car Car { get; set; }
    }
}
