using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace Base.Infrastructure.Extension.Swagger
{
	/// <summary>
	/// Swagger extension
	/// </summary>
	public static class SwaggerExtension
	{
		#region Swagger Configuration
		/// <summary>
		/// Method to configure the Swagger Services within the Application services interface
		/// </summary>
		/// <param name="services">The Service Collection <see cref="IServiceCollection"/></param>
		/// <param name="config">The Service Collection <see cref="IConfiguration"/></param>
		/// <param name="xmlAssemblyName">Assembly xml name: e.g. use: <code>Assembly.GetExecutingAssembly().GetName().Name;</code></cref></param>
		public static void ConfigureSwaggerExtension(this IServiceCollection services, IConfiguration config, string xmlAssemblyName)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = config["SwaggerConfiguration:Title"],
					Version = config["SwaggerConfiguration:Version"],
					Description = config["SwaggerConfiguration:Description"]
				});
				var ss = Assembly.GetExecutingAssembly().GetName().Name;
				// Set the comments path for the Swagger JSON and UI.
				// extension in the api
				//var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

				// Fix reference
				var xmlPath = string.Format(@$"{AppDomain.CurrentDomain.BaseDirectory}\{xmlAssemblyName}.xml");//Base.Api.xml
				c.IncludeXmlComments(xmlPath);
			});
		}
		#endregion

		/// <summary>
		/// Enable Swagger pipeline
		/// </summary>
		/// <param name="app">application configuration <see cref="IApplicationBuilder"/></param>
		/// <param name="config">application settings <see cref="IConfiguration"/></param>
		public static void EnableSwaggerPipeline(this IApplicationBuilder app, IConfiguration config)
		{
			app.UseSwagger();
			app.UseSwaggerUI(option =>
			{
				option.SwaggerEndpoint(
					config["SwaggerConfiguration:SwaggerJSONEndpoints"],
					$"{config["SwaggerConfiguration:Title"]} {config["SwaggerConfiguration:Version"]}");
				// To serve the Swagger UI at the apps root: index.html; launch settings = "launchUrl": "",
				option.RoutePrefix = string.Empty;
			});
		}
	}
}
