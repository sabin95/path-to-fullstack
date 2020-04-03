namespace BE.BL.Clients.Revisions
{
    public class Revision
    {
        public long Id { get; private set; }
        public long ClientId { get; private set; }
        public long CarId { get; private set; }
        public string Title { get; private set; }
        public string ProblemDetails { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsModified { get; private set; }

        public Revision(long id,long clientId, long carId, string title, string problemDetails)
        {
            Id = id;
            ClientId = clientId;
            CarId = carId;
            Title = title;
            ProblemDetails = problemDetails;
            
        }

        public Revision(long clientId, long carId, string title, string problemDetails)
            :this(0,clientId,carId,title,problemDetails)
        {
        }

        public void Edit(EditRevisionCommand editRevisionCommand)
        {
            IsModified = true;
            Title = editRevisionCommand.Title;
            ProblemDetails = editRevisionCommand.ProblemDetails;
        }
        public void Delete()
        {
            IsDeleted = false;
        }
    }
}
