using CadastroDeFamilias.Api.Library;
using CadastroDeFamilias.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Data.SqlClient;

namespace CadastroDeFamilias.Api
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
            var connectionString = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<CadastroDeFamiliasContext>(options => options.UseSqlServer(connectionString.ToString(), sqlO => { }));

            services.AddHttpContextAccessor();

            services.AddScoped<IUnitOfWork>(s => new CadastroDeFamiliasUnitOfWork(s.GetRequiredService<CadastroDeFamiliasContext>(), s.GetService<IHttpContextAccessor>()?.HttpContext?.User));

            services.AddResponseCaching();
            services.AddLocalization();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowAnyMethod().AllowCredentials();
                });
            });

            services.AddMemoryCache();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CadastroDeFamilias.Api", Version = "v1" });
            });

            services.AddAutoMapper(typeof(PerfilMapeamento));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CadastroDeFamilias.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
