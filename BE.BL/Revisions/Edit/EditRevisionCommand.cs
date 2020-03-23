namespace BE.BL.Revisions.Edit
{
    public class EditRevisionCommand
    {
        public string Title { get; set; }
        public string ProblemDetails { get; set; } 
        public long CarId { get; set; }
    }
}