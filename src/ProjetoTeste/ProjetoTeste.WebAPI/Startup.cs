using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetoTeste.Dominio;
using ProjetoTeste.Persistencia;

namespace ProjetoTeste.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ProjetoTesteContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Servico para Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Commands
            services.AddScoped<IRequestHandler<AdicionarProdutoCommand, string>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarProdutoCommand, string>, ProdutoCommandHandler>();

            // Persistencia
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ProjetoTesteContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
