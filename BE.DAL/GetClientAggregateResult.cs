using System;
using System.Collections.Generic;
using System.Text;

namespace BE.DAL
{
    public class GetClientAggregateResult
    {
        public long? ClientId { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public long? CarId { get; private set; }
        public string BrandName { get; private set; }
        public string ModelName { get; private set; }
        public string PlateNumber { get; private set; }
        public string RegistrationId { get; private set; }
        public long? RevisionId { get; private set; }
        public string Title { get; private set; }
        public string ProblemDetails { get; private set; }
    }
}
