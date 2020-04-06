namespace BE.BL.Clients.Revisions
{
    public class CreateRevisionCommand
    {
        public long ClientId { get; set; }
        public long CarId { get; set; }
        public string Title { get; set; }
        public string ProblemDetails { get; set; }         
    }
}