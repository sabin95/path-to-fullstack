using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using BE.Queries.Revisions.GetAllRevisions;
using BE.Queries.Revisions.GetRevisionById;
using BE.BL.Revisions.Create;
using BE.BL.Revisions.Edit;
using BE.Queries.Cars;
using BE.BL.Cars.Create;
using BE.BL.Cars.Edit;
using BE.Queries.Revisions.GetAllRevisionsByClientId;
using BE.Queries.Clients.GetClientResult;

namespace BE
{
    public class GetYourCarFixedDbContext : DbContext
    {    
        public GetYourCarFixedDbContext (DbContextOptions<GetYourCarFixedDbContext> dbContextOptions) :base(dbContextOptions)
        {           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetAllRevisionsResult>().HasNoKey();
            modelBuilder.Entity<GetRevisionsForClientResult>().HasNoKey();
            modelBuilder.Entity<GetRevisionResult>().HasNoKey();            
            modelBuilder.Entity<GetAllCarsForClientResult>().HasNoKey();
            modelBuilder.Entity<GetCarResult>().HasNoKey();
            modelBuilder.Entity<GetClientResult>().HasNoKey();
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
                   
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      
        public void ConfigureServices(IServiceCollection services)
        {    
            services.AddCors(c=>c.AddPolicy("myPolicy",b=>b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            services.AddDbContext<GetYourCarFixedDbContext>(options =>
                     options.UseSqlServer(Configuration.GetValue<string>("ConnectionString")));
        
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("myPolicy");
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(x=>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");
            });
            
        }
    }
}
