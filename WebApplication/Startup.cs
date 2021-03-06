using BLL;
using BLL.Service;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
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
            string connection = Configuration.GetConnectionString("dbConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connection));

            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();
            services.AddScoped<IRepository<Performance>, Repository<Performance>>();
            services.AddScoped<IRepository<Session>, Repository<Session>>();
            services.AddScoped<IRepository<TypeOfSeat>, Repository<TypeOfSeat>>();
            services.AddScoped<IRepository<Place>, PlaceRepository>();
            services.AddScoped<IRepository<Hall>, Repository<Hall>>();
            services.AddScoped<IRepository<Actor>, Repository<Actor>>();
            services.AddScoped<TicketSirvice>();
            services.AddScoped<DAL.TicketRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<PerformanceService>();
            services.AddScoped<PlaceService>();
            //services.AddScoped<IRepository<Session>, SessionRepository>();
            services.AddScoped<SessionRepository>();
            services.AddScoped<IRepository<AgeQualification>, Repository<AgeQualification>>();
            services.AddScoped<PerformanceReadOnlyRepository>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/User/AccessDenied");
                });

            services.AddControllers();
            services.AddControllersWithViews();

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Performance}/{action=ViewPerformances}/{id?}");
            });
        }
    }
}
