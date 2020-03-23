namespace BE.BL.Revisions.Create
{
    public class CreateRevisionCommand
    {
        public string Title { get; set; }
        public string ProblemDetails { get; set; } 
        public long CarId { get; set; }
    }
}