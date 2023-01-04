using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoCompany.Model.Entities;
using ToDoCompany.Service;
using ToDoCompany.Service.Mapper;
using ToDoCompany.Model;
using ToDoCompany.Repository;
using ToDoCompany.Model.Context;
using ToDoCompany.Service.DTOs;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ToDoCompany.Service.FluentValidation;

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
            services.AddDbContext<CompanyDbContext>(
                options => options.
                UseMySql(Configuration.
                GetConnectionString("DefaultConnections")));
            services.AddScoped<IBaseRepository<Employee>,EmployeeRepository>();
            services.AddScoped<IBaseRepository<EmployeeTask>, EmployeeTaskRepository>();
            services.AddScoped<IBaseValidator>();
             var mapperConfig = new MapperConfiguration(x => {
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
