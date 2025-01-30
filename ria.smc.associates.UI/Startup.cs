using Microsoft.AspNetCore.Authentication.Cookies;
using ria.smc.associates.UI.Utilities;
using Microsoft.AspNetCore.Http.Features;
using FluentValidation.AspNetCore;
using ria.smc.associates.UI.Utilities.Attributes;
using ApiCaller.ServiceCaller;

namespace ria.smc.associates.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/User";
                    option.Cookie.Name = AppConstants.COOKIE_USER_KEY;
                });
            services.AddControllersWithViews();
            services.AddMvc(
                config =>
                {
                    config.Filters.Add(typeof(CustomExceptionHandler));
                }
            ).AddFluentValidation();

            services.AddMvc();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.Use(async (ctx, next) =>
                {
                    await next();

                    if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                    {
                        string originalPath = ctx.Request.Path.Value;
                        ctx.Items["originalPath"] = originalPath;
                        ctx.Request.Path = "/Home/NotFound";
                        await next();
                    }
                });
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "HR",
                    pattern: "{area:exists}/{controller=EmployeeRegistration}/{action=Index}/{id?}");

                // Default route for general usage
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Login}/{id?}");

                
            });



        }
    }
}
