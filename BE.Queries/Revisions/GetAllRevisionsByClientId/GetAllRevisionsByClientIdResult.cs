namespace BE.Queries.Revisions.GetAllRevisionsByClientId
{
    public class GetAllRevisionsByClientIdResult
    {
        public long Id { get; set; }
        public int ClientId { get; set; }
        public string ProblemDetails { get; set; } 
        public BE.DAL.Car Car { get; set; }
    }
}
