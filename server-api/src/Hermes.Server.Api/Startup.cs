namespace Hermes.Server.Api
{
	using Hermes.Server.Api.Core;
	using Hermes.Server.Api.Core.Anagrams;
	using Hermes.Server.Api.Data.FileIO;

	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.OpenApi.Models;
	
	using System.Threading;
	using System.Threading.Tasks;

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
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
				{
					builder.AllowAnyOrigin();
				});
			});

			// Hermes.Server.Api.Core
			services.AddSingleton<IDictionaryProviderFactory, TextFileDictionaryProviderFactory>();
			services.AddSingleton<IDictionaryProvider>(x =>
			{
				return x.GetRequiredService<IDictionaryProviderFactory>()
					.Create(Thread.CurrentThread.CurrentCulture.Name);
			});

			// Hermes.Server.Api.Core.Anagrams
			services.AddSingleton<IAnagramsProvider, AnagramsProvider>();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hermes.Server.Api", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hermes.Server.Api v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseCors();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}