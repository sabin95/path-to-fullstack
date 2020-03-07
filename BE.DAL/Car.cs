namespace BE.DAL
{
    public class Car
    {
        public long CarId { get; set; }
        public long UserId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }
    }
}