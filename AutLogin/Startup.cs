using AutoLogin.Application;
using AutoLogin.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace AutLogin;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public object JwtBearrerDefaults { get; private set; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAplicationService();
        services.AddPersistenceRepository(Configuration);
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never;
        });

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader()
            );
        });

        services.AddLogging(logging =>
        {
            logging.AddConsole();
            logging.AddDebug();
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JwtSettings:Issuer"],
                        ValidAudience = Configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Secret"]))
                    };
                });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("CorsPolicy");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}