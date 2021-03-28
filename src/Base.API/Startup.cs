using Base.Infrastructure.Extension.Database;
using Base.Infrastructure.Extension.DependencyInjection;
using Base.Infrastructure.Extension.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Base.API
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


			#region Swagger extension
			services.ConfigureSwaggerExtension(_configuration, Assembly.GetExecutingAssembly().GetName().Name);
			#endregion

			#region Database context service
			// TODO: before use this, create your own dbcontext
			services.UsePostgreSqlServer(_configuration.GetConnectionString("DefaultConnection"), _configuration);

            // in memory db
            // services.UseInMemoryDatabase();
            #endregion

            services.AddApplication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // swagger pipeline
                app.EnableSwaggerPipeline(_configuration);
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
