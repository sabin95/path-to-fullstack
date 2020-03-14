namespace BE.Queries.Revisions.GetRevisionById
{
    public class GetRevisionByIdResult
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string ProblemDetails { get; set; } 
        public long CarId { get; set; }
    }
}
