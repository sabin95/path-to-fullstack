namespace BE.BL.Revisions.Create
{
    public class RevisionCreateCommand
    {      
        public string ProblemDetails { get; set; } 
        public long CarId { get; set; }
    }
}