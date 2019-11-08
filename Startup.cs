using Lucilvio.TicketMe.AnemicModel.Domain.Client;
using Lucilvio.TicketMe.AnemicModel.Tickets;
using Lucilvio.TicketMe.AnemicModel.Clients;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lucilvio.TicketMe.AnemicModel.Users;

namespace Lucilvio.TicketMe
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
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Clear();
                options.ViewLocationFormats.Add("/Shared/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/{1}/{0}/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Tickets/Tickets";
                });

            services.AddSingleton<IPasswordHiding, PasswordHideWithHash>();

            services.AddSingleton(services =>
            {
                return new MemoryContext((IPasswordHiding)services.GetService(typeof(IPasswordHiding)));
            });

            services.AddScoped<ITicketsServiceRepository, TicketsServiceRepositoryInMemory>();
            services.AddScoped<ITicketDetailServiceRepository, TicketDetailServiceDetailRepositoryInMemory>();
            services.AddScoped<IBuyTicketServiceRepository, BuyTicketServiceRepositoryInMemory>();
            services.AddScoped<IClientServiceRepository, ClientServiceRepositoryInMemory>();
            services.AddScoped<IUseClientTicketServiceRepository, UseClientTicketServiceRepositoryInMemory>();
            services.AddScoped<IClientPointsServiceRepository, ClientPointsServiceRepositoryInMemory>();
            services.AddScoped<IUserSignInServiceRepository, UserSignInServiceRepositoryInMemory>();
            services.AddScoped<IRegisterNewClientServiceRepository, RegisterNewClientServiceRepositoryInMemory>();
            services.AddScoped<IRegisterNewTicketServiceRepository, RegisterNewTicketServiceRepositoryInMemory>();
            services.AddScoped<IManageTicketsServiceRepository, ManageTicketsServiceRepositoryInMemory>();
            services.AddScoped<IEditTicketServiceRepository, EditTicketServiceRepositoryInMemory>();
            services.AddScoped<IDisableTicketServiceRepository, DisableTicketServiceRepositoryInMemory>();
            services.AddScoped<IEnableTicketServiceRepository, EnableTicketServicerepositoryInMemory>();

            services.AddScoped<ITicketsService, TicketsService>();
            services.AddScoped<ITicketsService, TicketsService>();
            services.AddScoped<ITicketDetailService, TicketDetailService>();
            services.AddScoped<IBuyTicketService, BuyTicketService>();
            services.AddScoped<IClienteService, ClientService>();
            services.AddScoped<IUseClientTicketService, UseClientTicketService>();
            services.AddScoped<IClientPointsService, ClientPointsService>();
            services.AddScoped<IUserSignInService, UserSignInService>();
            services.AddScoped<IRegisterNewClientService, RegisterNewClientService>();
            services.AddScoped<IRegisterNewTicketService, RegisterNewTicketService>();
            services.AddScoped<IManageTicketsService, ManageTicketsService>();
            services.AddScoped<IEditTicketService, EditTicketService>();
            services.AddScoped<IDisableTicketService, DisableTicketService>();
            services.AddScoped<IEnableTicketService, EnableTicketService>();

            services.AddControllersWithViews();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Tickets}/{action=Tickets}/{id?}");
            });
        }
    }
}
