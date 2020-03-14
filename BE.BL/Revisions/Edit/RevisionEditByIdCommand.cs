namespace BE.BL.Revisions.Edit
{
    public class RevisionEditByIdCommand
    {      
        public string ProblemDetails { get; set; } 
        public long CarId { get; set; }
    }
}