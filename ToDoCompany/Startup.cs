using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using ToDoCompany.Model.Context;
using ToDoCompany.Model.Entities;
using ToDoCompany.Repository;
using ToDoCompany.Service.DTOs;
using ToDoCompany.Service.FluentValidation;
using ToDoCompany.Service.Mapper;

namespace ToDoCompany
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
             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompanyCRUD", Version = "v1" });

            });
            services.AddControllers();
            services.AddDbContext<CompanyDbContext>(
                options => options.
                UseMySql(Configuration.
                GetConnectionString("DefaultConnections")));
            services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IBaseRepository<EmployeeTask>, EmployeeTaskRepository>();
            services.AddScoped<IValidator<EmployeeDto>, EmployeeValidation>();
            services.AddScoped<IValidator<EmployeeTaskDto>, EmployeeTaskValidation>();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<EmployeeProfile>();
                x.AddProfile<EmployeeTaskProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyCRUD v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
