using AutoMapper;
using BookMyShow.Models;
using BookMyShow.Services.AuthenticationService;
using BookMyShow.Services.BookingService;
using BookMyShow.Services.BookMyShowDBContext;
using BookMyShow.Services.CityService;
using BookMyShow.Services.HallService;
using BookMyShow.Services.MoviesService;
using BookMyShow.Services.SeatService;
using BookMyShow.Services.ShowService;
using BookMyShow.Services.TheatreService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SimpleInjector;
using System;
using System.Text;

namespace BookMyShow
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();
        private readonly string CorsPolicy = "_cors";
        public Startup(IConfiguration configuration)
        {
            container.Options.ResolveUnregisteredConcreteTypes = false;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_SeceretKey"].ToString());

            services.AddControllers();
            services.AddRazorPages();
            services.AddLocalization();

            services.AddDbContext<AuthenticationContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("BookMyShowDB"));
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AuthenticationContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(auth =>
            {
                auth.RequireHttpsMetadata = false;
                auth.SaveToken = false;
                auth.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddCors(
                options =>
                {
                    options.AddPolicy(name: CorsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                        
                    });
                }
            );
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and
                // allows request-scoped framework services to be resolved.
                options.AddAspNetCore()



                    // Ensure activation of a specific framework type to be created by
                    // Simple Injector instead of the built-in configuration system.
                    // All calls are optional. You can enable what you need. For instance,
                    // ViewComponents, PageModels, and TagHelpers are not needed when you
                    // build a Web API.
                    .AddControllerActivation()
                    .AddViewComponentActivation()
                    .AddPageModelActivation()
                    .AddTagHelperActivation();



                // Optionally, allow application components to depend on the non-generic
                // ILogger (Microsoft.Extensions.Logging) or IStringLocalizer
                // (Microsoft.Extensions.Localization) abstractions.
                options.AddLogging();
                options.AddLocalization();
            });
            InitializeContainer();

        }
        public void InitializeContainer()
        {
            container.Register<IMovieService, MovieService>();
            container.Register<ICityService, CityService>();
            container.Register<ITheatreService, TheatreService>();
            container.Register<IHallService, HallService>();
            container.Register<ISeatService, SeatService>();
            container.Register<IShowService, ShowService>();
            container.Register<IBookingService, BookingService>();
            container.Register<IAuthenticationService, AuthenticationService>();
            container.Register<IBookMyShowDbContextService, BookMyShowDbContextService>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseCors(CorsPolicy);

            
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
