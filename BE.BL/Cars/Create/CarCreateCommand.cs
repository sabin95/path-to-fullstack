namespace BE.BL.Cars.Create
{
    public class CarCreateCommand
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }
    }
}