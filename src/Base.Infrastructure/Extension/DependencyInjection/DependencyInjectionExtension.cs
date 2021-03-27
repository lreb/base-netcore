using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using static Base.Service.Features.ItemFeatures.Query.GetAllItemsQuery;

namespace Base.Infrastructure.Extension.DependencyInjection
{
	public static class DependencyInjectionExtension
	{
		public static void AddApplication(this IServiceCollection services)
		{
			// Same project startup.cs
			//services.AddMediatR(Assembly.GetExecutingAssembly());

			// if you have handlers/events in other assemblies
			services.AddMediatR(typeof(GetAllItemsQueryHandler).Assembly);

		}
	}
}
