using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TimeSheets.DAL;
using TimeSheets.DAL.Repositories;
using TimeSheets.DAL.Repositories.Interfaces;
using TimeSheets.DAL.Services;
using TimeSheets.DAL.Services.Interfaces;
using TimeSheets.DTO;

namespace TimeSheets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IContractService, ContractService>();
            
            services.AddControllers();
            
            services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseNpgsql(Configuration["ConnectionString"]));
            
            MapperConfiguration mapperConfiguration = new MapperConfiguration(
                mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "TimeSheets", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeSheets v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}