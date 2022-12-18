using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ctest
{
	public class Startup
	{
		private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().AddNewtonsoftJson();
			services.AddMvc().AddNewtonsoftJson(delegate (MvcNewtonsoftJsonOptions options)
			{
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});
			services.AddSwaggerGen(delegate (SwaggerGenOptions c)
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "WebAPI",
					Version = "v1"
				});
				OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme
				{
					Name = "JWT Authentication",
					Description = "Enter JWT Bearer token **_only_**",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					BearerFormat = "JWT",
					Reference = new OpenApiReference
					{
						Id = "Bearer",
						Type = ReferenceType.SecurityScheme
					}
				};
				c.AddSecurityDefinition(openApiSecurityScheme.Reference.Id, openApiSecurityScheme);
				c.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
					openApiSecurityScheme,
					new string[0]
				} });
			});
			services.AddAuthentication("Bearer").AddJwtBearer("Bearer", delegate (JwtBearerOptions options)
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = "Security:Tokens:Issuer",
					ValidateAudience = true,
					ValidAudience = "Security:Tokens:Audience",
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Security:Tokens:Key"))
				};
			});
			services.AddCors(delegate (CorsOptions options)
			{
				options.AddPolicy(MyAllowSpecificOrigins, delegate (CorsPolicyBuilder builder)
				{
					builder.WithOrigins("http://localhost:5173", "http://34.172.211.20").AllowAnyHeader().AllowAnyMethod();
				});
			});
			//services.Configure(delegate (MvcOptions options)
			//{
			//	options.Filters.Add(new RequireHttpsAttribute());
			//});
			//services.AddMvc(delegate (MvcOptions options)
			//{
			//	options.SslPort = 5001;
			//});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(delegate (SwaggerUIOptions c)
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
				});
			}
			//app.UseHttpsRedirection();
			app.UseRouting();
			app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(delegate (IEndpointRouteBuilder endpoints)
			{
				endpoints.MapControllers();
			});
			//int value = 5001;
			//app.UseRewriter(new RewriteOptions().AddRedirectToHttps(301, value));



		}
	}
}
