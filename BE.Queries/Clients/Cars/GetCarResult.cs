namespace BE.Queries.Clients.Cars
{
    public class GetCarResult
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }
    }
}