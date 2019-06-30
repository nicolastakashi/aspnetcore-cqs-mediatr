using System.Collections.Generic;
using CQS.Api.CommandHandlers;
using CQS.Api.Commands;
using CQS.Api.Domain.Queries;
using CQS.Api.Domain.Queries.Results;
using CQS.Api.Domain.QueryHandlers;
using CQS.Api.Infra.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CQS.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMediatR(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<AsyncRequestHandler<CreateUserCommand>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<GetPagedUsersQuery, IEnumerable<GetPagedUsersQueryResult>>, UserQueryHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}
