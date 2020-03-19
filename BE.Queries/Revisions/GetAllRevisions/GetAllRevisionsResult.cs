namespace BE.Queries.Revisions.GetAllRevisions
{
    public class GetAllRevisionsResult
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Title { get; set; }
        public string ProblemDetails { get; set; } 
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }
    }
}
