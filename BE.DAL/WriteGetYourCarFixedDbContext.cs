using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BE.DAL
{
    public class WriteGetYourCarFixedDbContext : DbContext
    {
        public WriteGetYourCarFixedDbContext(DbContextOptions<WriteGetYourCarFixedDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
