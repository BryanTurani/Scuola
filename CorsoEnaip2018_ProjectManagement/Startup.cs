using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CorsoEnaip2018_ProjectManagement
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Project}/{action=Index}/{id?}");
            });

            /* Gestione progetti di un'azienda
             * Ogni progetto ha:
             * 
             * Nome - stringa
             * Cliente - stringa
             * Manager - stringa
             * DataInizio - data
             * DataFine - data
             * DataConsegna - data
             * Prezzo - decimal
             * Costo - decimal
             * 
             * Pagine:
             *   - Lista di progetti,
             *   - Modifica pogetto,
             *   - Eliminazione progetto
             */
        }
    }
}
