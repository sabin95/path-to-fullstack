using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using BE.Queries;
using BE.DAL;
using BE.Queries.Clients;
using BE.BL.Clients;

namespace BE
{
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
            services.AddDbContext<ReadGetYourCarFixedDbContext>(options =>
                     options.UseSqlServer(Configuration.GetValue<string>("ConnectionString")));
            services.AddDbContext<WriteGetYourCarFixedDbContext>(options =>
                     options.UseSqlServer(Configuration.GetValue<string>("ConnectionString")));
            services.AddScoped<IClientsReadRepository, ClientsReadRepository>();
            services.AddScoped<IClientsWriteRepository, ClientsWriteRepository>();
            services.AddScoped<IClientAggregateFactory, ClientAggregateFactory>();

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
