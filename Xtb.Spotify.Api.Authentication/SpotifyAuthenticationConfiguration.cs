using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Net.Http;
using System.Security.Claims;
using Xtb.Spotify.Api.Authentication;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SpotifyAuthenticationConfiguration
    {
        public static void AddSpotifyAuthentiation(this IServiceCollection services)
        {
            services.AddAuthentication(
                        options =>
                        {
                            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = SpotifyAuthenticationDefaults.AuthenticationScheme;
                        }
                )
                .AddCookie()
                .AddOAuth(SpotifyAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.AuthorizationEndpoint = "https://accounts.spotify.com/authorize";
                    options.CallbackPath = "/auth/grant";
                    options.ClientId = "0b361c2fdde54ae5ba312d12019f1e10";
                    options.ClientSecret = "9b796b357790441e8e724fa60fadc6a7";
                    options.TokenEndpoint = "https://accounts.spotify.com/api/token";
                    options.UserInformationEndpoint = "https://api.spotify.com/v1/me";

                    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "display_name");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "display_name");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

                    options.SaveTokens = true;

                    options.Events = new OAuthEvents
                    {
                        OnCreatingTicket = async context =>
                        {
                            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.AccessToken);

                            var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                            response.EnsureSuccessStatusCode();

                            var content = await response.Content.ReadAsStringAsync();
                            using (var user = System.Text.Json.JsonDocument.Parse(content))
                            {
                                context.RunClaimActions(user.RootElement);
                            }

                            var tokenService = context.HttpContext.RequestServices.GetService<ITokenWriterService>();
                            tokenService.ApiToken = context.AccessToken;
                        }
                    };
                });
        }
    }
}