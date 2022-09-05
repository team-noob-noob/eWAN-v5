using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace NoobNoob.eWAN.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>()
        {
            new ApiResource("APIS")
            {
                Scopes = { "APIS" }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("APIS"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "http://localhost:5000/swagger/oauth2-redirect.html", "http://localhost:5000/signin-oidc" },
                FrontChannelLogoutUri = "http://localhost:5000/signout-oidc",
                PostLogoutRedirectUris = { "http://localhost:5000/signout-callback-oidc" },
                RequirePkce = false,
                AllowAccessTokensViaBrowser = true,
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    "APIS",
                },
                Enabled = true,
            },
        };
}