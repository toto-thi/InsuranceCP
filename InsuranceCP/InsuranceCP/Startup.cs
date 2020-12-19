using InsuranceCP.Data;
using InsuranceCP.Data.CategoryRepo;
using InsuranceCP.Data.CompanyRepo;
using InsuranceCP.Data.Level_SubRepo;
using InsuranceCP.Data.LevelRepo;
using InsuranceCP.Data.Turbo_LevelRepo;
using InsuranceCP.Data.VehicleRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace InsuranceCP
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

            services.AddControllers();
            // Mongo
            services.AddOptions();
            services.Configure<Settings>(Configuration.GetSection(nameof(Settings)));
            services.AddSingleton<Settings>(sp =>
                            sp.GetRequiredService<IOptions<Settings>>().Value);
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IComRepo,QComRepo>();
            services.AddScoped<ICateRepo, QCateRepo>();
            services.AddScoped<ILvelSubRepo, QLvelSubRepo>();
            services.AddScoped<ILvelRepo, QLvelRepo>();
            services.AddScoped<ITurboRepo, QTurboRepo>();
            services.AddScoped<IVehicleRepo, QVehicleRepo>();
            services.AddCors(o => o.AddPolicy("MyCORSPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        

            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InsuranceCP", Version = "v1" });
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                /*app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InsuranceCP v1"));*/
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("MyCORSPolicy");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
