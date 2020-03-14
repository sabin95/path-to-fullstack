namespace BE.Queries.Revisions.GetAllRevisionsByClientId
{
    public class GetAllRevisionsByClientIdResult
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string ProblemDetails { get; set; } 
        public long CarId { get; set; }
    }
}
