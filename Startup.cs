using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProtal_KF
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
			services.AddControllersWithViews();
			services.AddRazorPages().AddRazorRuntimeCompilation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = ctx =>
				{
					const int durationInSeconds = 7 * 60 * 60 * 24; //7 days
					ctx.Context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.CacheControl] =
						"public,max-age=" + durationInSeconds;
				}
			});

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				  name: "Feature",
				  pattern: "tinh-nang/quan-ly-vung-trong",
				  defaults: new { controller = "Feature", action = "AreaManage" });

				endpoints.MapControllerRoute(
				  name: "Feature",
				  pattern: "tinh-nang/nhat-ky-nong-ho",
				  defaults: new { controller = "Feature", action = "FarmerDiary" });

				endpoints.MapControllerRoute(
				  name: "Feature",
				  pattern: "tinh-nang/phieu-khao-sat",
				  defaults: new { controller = "Feature", action = "SurveySheet" });

				endpoints.MapControllerRoute(
				  name: "Feature",
				  pattern: "tinh-nang/ket-noi-thiet-bi-iot",
				  defaults: new { controller = "Feature", action = "ConnectIot" });

				endpoints.MapControllerRoute(
				  name: "Feature",
				  pattern: "tinh-nang",
				  defaults: new { controller = "Feature", action = "Index" });

				endpoints.MapControllerRoute(
					name: "Contact",
					pattern: "lien-he",
					defaults: new { controller = "Contact", action = "Index" });

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
