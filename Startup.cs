using Desaprendiendo.Services.Mail;
using Desaprendiendo.Services.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Desaprendiendo
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default30",
                    new CacheProfile()
                    {
                        Duration = 30
                    });
            });
            services.AddControllersWithViews();
            services.AddResponseCaching();
            services.AddResponseCompression();
            services.AddRazorPages();
            const string connection = @"Server=tcp:desaprendiendo.database.windows.net,1433;Initial Catalog=desaprendiendoDB;Persist Security Info=False;User ID=jacintoaisa;Password=P0t@to!!!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<DBContextEF>(options => options.UseSqlServer(connection));
            services.AddScoped<ICategoriaRepository, CategoryRepository>();
            services.AddScoped<ISubCategoriaRepository, SubCategoryRepository>();
            services.AddScoped<ICursoRepository, GenericRepository>();
            services.AddScoped<IModuloRepository, ModuloRepository>();
            services.AddScoped<ILeccionRepository, LeccionRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddTransient<IEMail, EMail>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IFileProvider>(
                    new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddMemoryCache();
            //services.AddDistributedMemoryCache();
            services.Configure<MailConfiguration>(Configuration.GetSection("EmailSettings"));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            //app.UseCookiePolicy();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseResponseCaching();
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "SitioWeb",
                    pattern: "https:/desaprendiendo.net/modulosfront/index/32",
                    defaults: new { controller = "CursosFront", action = "Index", id = 12 });
                endpoints.MapControllerRoute(
                    name: "Procesos",
                    pattern: "https:/desaprendiendo.net/modulosfront/index/36",
                    defaults: new { controller = "CursosFront", action = "Index", id = 16 });
                endpoints.MapControllerRoute(
                    name: "BI",
                    pattern: "https:/desaprendiendo.net/cursosfront/index/14",
                    defaults: new { controller = "CursosFront", action = "Index", id = 14 });
                endpoints.MapControllerRoute(
                    name: "cursoAnalisisDatos",
                    pattern: "cursoAnalisisDatos",
                    defaults: new { controller = "ModulosFront", action = "Index", id = 109 });
                endpoints.MapControllerRoute(
                    name: "redesYSistemas",
                    pattern: "redesYSistemas",
                    defaults: new { controller = "SubCategoriasFront", action = "Index", id = 0 });
                endpoints.MapControllerRoute(
                    name: "desarrollo",
                    pattern: "desarrollo",
                    defaults: new { controller = "SubCategoriasFront", action = "Index", id = 1 });
                endpoints.MapControllerRoute(
                    name: "bi",
                    pattern: "bi",
                    defaults: new { controller = "SubCategoriasFront", action = "Index", id = 3 });
                endpoints.MapControllerRoute(
                    name: "dynamicsNav",
                    pattern: "dynamicsNav",
                    defaults: new { controller = "SubCategoriasFront", action = "Index", id = 4 });
                endpoints.MapControllerRoute(
                    name: "seo",
                    pattern: "seo",
                    defaults: new { controller = "SubCategoriasFront", action = "Index", id = 6 });
                endpoints.MapControllerRoute(
                    name: "categoria",
                    pattern: "categoria",
                    defaults: new { controller = "CategoriaFront", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "tripartita",
                    pattern: "tripartita",
                    defaults: new { controller = "CategoriaFront", action = "Tripartita" });
                endpoints.MapControllerRoute(
                    name: "metodologia",
                    pattern: "metodologia",
                    defaults: new { controller = "CategoriaFront", action = "Metodologia" });
                endpoints.MapControllerRoute(
                    name: "nosotros",
                    pattern: "nosotros",
                    defaults: new { controller = "CategoriaFront", action = "Nosotros" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CategoriaFront}/{action=Home}/{id?}");
            });
        }

    }
}

