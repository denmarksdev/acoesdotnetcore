using AcoesDotNet.Model;
using AcoesDotNet.Repository;
using AcoesDotNet.Repository.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace AcoesDotNet.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IDatabaseRepository, DataBaseRepository>();
            services.AddTransient<IGenericRepository<Cliente>, GenericRepository<Cliente>>();
            services.AddTransient<IGenericRepository<Acao>, GenericRepository<Acao>>();
            services.AddTransient<IOrdemRepository,OrdemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();

            await InicializaBaseDados(app);
        }

        private async Task InicializaBaseDados(IApplicationBuilder app)
        {
            var connectionString = Configuration.GetValue<string>("SqlServerConnectioString");
            var databaseRepo = app.ApplicationServices.GetService<IDatabaseRepository>();
            await databaseRepo.InicializaAsync(connectionString);
        }
    }
}
