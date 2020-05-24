using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Xtb.Spotify.Api.MvcClient
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
            services.AddControllersWithViews();

            services.AddSpotifyAuthentiation();
            // HACK: This is what AddSpotifyAuthentiation() is supposed to do
            // but there's a version mismatch that I'll sort later that
            // means that RunClaimActions() has issues if we move this
            // into it's own assembly
            //services.AddAuthentication(
            //            options =>
            //            {
            //                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //                options.DefaultChallengeScheme = SpotifyAuthenticationDefaults.AuthenticationScheme;
            //            }
            //    )
            //    .AddCookie()
            //    .AddOAuth(SpotifyAuthenticationDefaults.AuthenticationScheme, options =>
            //    {
            //        options.AuthorizationEndpoint = "https://accounts.spotify.com/authorize";
            //        options.CallbackPath = "/auth/grant";
            //        options.ClientId = "0b361c2fdde54ae5ba312d12019f1e10";
            //        options.ClientSecret = "9b796b357790441e8e724fa60fadc6a7";
            //        options.TokenEndpoint = "https://accounts.spotify.com/api/token";
            //        options.UserInformationEndpoint = "https://api.spotify.com/v1/me";

            //        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "display_name");
            //        options.ClaimActions.MapJsonKey(ClaimTypes.Name, "display_name");
            //        options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

            //        options.SaveTokens = true;

            //        options.Events = new OAuthEvents
            //        {
            //            OnCreatingTicket = async context =>
            //            {
            //                var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
            //                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.AccessToken);

            //                var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
            //                response.EnsureSuccessStatusCode();

            //                var content = await response.Content.ReadAsStringAsync();
            //                using (var user = System.Text.Json.JsonDocument.Parse(content))
            //                {
            //                    context.RunClaimActions(user.RootElement);
            //                }

            //                var tokenService = context.HttpContext.RequestServices.GetService<ITokenWriterService>();
            //                tokenService.ApiToken = context.AccessToken;
            //            }
            //        };
            //    });
            services.AddSpotifyApiClient();
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

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Lax // Required for OAuth2 suport
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
