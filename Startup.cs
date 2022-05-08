using Fizzy_Airline.Helpers;
using Fizzy_Airline.Middleware;
using Fizzy_Airline.Repository;
using Fizzy_Airline.Repository.Interface;
using Fizzy_Airline.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Services;

namespace Fizzy_Airline
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
			services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			// configure strongly typed settings object
			services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddSwaggerGen();
			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
			// configure DI for application services
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IEmailService, EmailService>();
			services.AddTransient<IAirplaneRepository, AirplaneRepository>();
			services.AddTransient<IFlightAttendantRepository, FlightAttendantRepository>();
			services.AddTransient<ILocationRepository, LocationRepository>();
			services.AddTransient<IPassengerRepository, PassengerRepository>();
			services.AddTransient<IPilotRepository, PilotRepository>();
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fizzy_Airline", Version = "v1" });

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
						Reference = new OpenApiReference
						{
							Type=ReferenceType.SecurityScheme,
							Id="Bearer"
						}
					},
					new string[]{}
				}
					});
				});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fizzy_Airline v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			// global cors policy
			app.UseCors(x => x
				.SetIsOriginAllowed(origin => true)
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials());

			app.UseAuthentication();
			app.UseAuthorization();

			// global error handler
			app.UseMiddleware<ErrorHandlerMiddleware>();

			// custom jwt auth middleware
			app.UseMiddleware<JwtMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
