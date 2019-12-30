using AutoMapper;
using LaunchAPIConsole.Data.ApiModels.SpaceX.Launches;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceLaunchTracker.Configuration;
using SpaceLaunchTracker.Data;
using SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches;
using SpaceLaunchTracker.Data.Clients;
using SpaceLaunchTracker.Data.Repository;
using SpaceLaunchTracker.Mappings;
using SpaceLaunchTracker.Services;

namespace SpaceLaunchTracker
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
            services.AddCors(o => o.AddPolicy("ReactPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<DataUpdatesConfiguration>(Configuration);

            services.AddAutoMapper(typeof(DomainProfile));
            services.AddMvc(options => options.EnableEndpointRouting = false).AddNewtonsoftJson();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Space launch tracker API", Description = "Swagger space launch tracker API" });
            //});
            services.AddHostedService<LaunchesUpdateService>();

            services.AddDbContext<SpaceLaunchTrackerDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Default")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("UsersConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ILaunchRepository, LaunchRepository>();
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ILaunchClient<SpaceXLaunchModel>, SpaceXClient>();
            services.AddScoped<ILaunchClient<LibraryLaunchModel>, LaunchLibraryClient>();
            services.AddScoped<LaunchService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("ReactPolicy");

            //app.UseDeveloperExceptionPage();
            //app.UseExceptionHandler("/Launches/Error");
            //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //app.UseHsts();

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();

            //app.UseAuthentication();

            //app.UseMvc();

            ////app.UseSwagger();
            ////app.UseSwaggerUI(c =>
            ////{
            ////    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Space launch tracker API");
            ////});
        }
    }
}