using Abp.AspNetCore.SignalR.Hubs;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using CookingPortal.Extensions;
using CookingPortal.Hubs;
using CookingPortal.Mapper;
using CookingPortal.Middleware;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(RecipeProfile));
            services.AddAutoMapper(typeof(UserRecipeProfile));

            services.AddControllers();

            //services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });//если заработает - добавить
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(Configuration.GetDbConnectionString(Environment)));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeCommentRepository, RecipeCommentRepository>();
            services.AddScoped<INotificationSettingsRepository, NotificationSettingsRepository>();
            services.AddScoped<IPersonalSettingsRepository, PersonalSettingsRepository>();

            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRecipeService, RecipeService>();

            services.AddValidators();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(x => x.LoginPath = "/User/Login");
            
            services.AddSignalR();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var myDbContext = services.GetService<ApplicationDbContext>();
                myDbContext.SeedSampleData();
            }

            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins("http://localhost:44388").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            //});

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHub<AbpCommonHub>("/signalr");
                endpoints.MapHub<ChatHub>("/Home/Index");

                endpoints.MapControllerRoute(//роутинг
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
