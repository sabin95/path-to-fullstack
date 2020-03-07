namespace BE.Queries.Car
{
    public class GetAllCarsByClientIdResult
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }
    }
}