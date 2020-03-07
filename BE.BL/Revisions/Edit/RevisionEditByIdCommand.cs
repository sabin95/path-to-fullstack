namespace BE.BL.Revisions.Edit
{
    public class RevisionEditByIdCommand
    {      
        public string ProblemDetails { get; set; } 
        public int ClientId { get; set; }
        public BE.DAL.Car Car { get; set; }
    }
}