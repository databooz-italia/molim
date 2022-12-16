using System.Text;
using Molim.Backend.API.Auth;
using Molim.Backend.API.BusinessLayer.Data;
using Molim.Backend.API.BusinessLayer.Services;
using Molim.Backend.API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Molim.Backend.API.BusinessLayer.Interfaces;
using Serilog;
using Microsoft.EntityFrameworkCore;

namespace Molim.Backend.API
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddControllers();

            #region App Services Configuration

            services.AddDbContext<MolimDb>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"), sql => sql.MigrationsAssembly(typeof(Startup).Assembly.FullName)).EnableSensitiveDataLogging());
            services.AddScoped<BaseService>(x => new BaseService(x.GetService<MolimDb>(), x.GetService<Configuration>(), x.GetService<IAuthenticationProvider>(), x.GetService<Microsoft.Extensions.Logging.ILogger<BaseService>>()));            

            #endregion

            #region APP Settings Configuration

            Configuration conf = new Configuration();
            Configuration.GetSection("AppConfiguration").Bind(conf);

            services.AddSingleton(conf);

            #endregion

            #region JWT Authentication Configuration

            JWTConfiguration jwtConf = new JWTConfiguration();
            Configuration.GetSection("JWTConfiguration").Bind(jwtConf);

            services.AddSingleton(jwtConf);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConf.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<TokensProvider>();

            #endregion

            services.AddSingleton<IHttpContextAccessor, AuthenticationProvider>();
            services.AddSingleton<IAuthenticationProvider, AuthenticationProvider>();

            services.AddOpenApiDocument();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, MolimDb db)
        {
            //APPLY ALL MIGRATIONS
            db.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

            app.UseSerilogRequestLogging();

            app.UseRouting();            

            app.UseAuthorization();

            app.UseMiddleware<SerilogUserDataMiddleware>();

            app.UseManagedExceptionHandler(loggerFactory.CreateLogger<Controller>());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
