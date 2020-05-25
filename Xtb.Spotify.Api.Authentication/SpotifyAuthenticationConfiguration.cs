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
        public static void AddSpotifyAuthentiation(this AuthenticationBuilder builder, SpotifyAuthenticationOptions spotifyAuthenticationOptions)
        {
            var defaults = SpotifyAuthenticationOptions.Default;

            builder.AddOAuth(SpotifyAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.AuthorizationEndpoint = spotifyAuthenticationOptions?.AuthorizationEndpoint ?? defaults.AuthorizationEndpoint;
                    options.CallbackPath = spotifyAuthenticationOptions?.CallbackPath ?? defaults.CallbackPath;
                    options.ClientId = spotifyAuthenticationOptions?.ClientId ?? defaults.ClientId;
                    options.ClientSecret = spotifyAuthenticationOptions.ClientSecret ?? defaults.ClientSecret;
                    options.TokenEndpoint = spotifyAuthenticationOptions?.TokenEndpoint ?? defaults.TokenEndpoint;
                    options.UserInformationEndpoint = spotifyAuthenticationOptions?.UserInformationEndpoint ?? defaults.UserInformationEndpoint;

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