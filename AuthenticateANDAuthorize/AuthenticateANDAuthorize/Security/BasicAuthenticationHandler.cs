using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace AuthenticateANDAuthorize.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOption>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. Bak bakalım httpHeader içinde Authorization ifadesi var mı?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //2. Authorization ifadesi doğru formatta mı?
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //3. Authorization ifadesinin tipi Basic mi?
            if (headerValue.Scheme != "Basic")
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            byte[] headerValueBytes = Convert.FromBase64String(headerValue.Parameter);
            string headerValueString = Encoding.UTF8.GetString(headerValueBytes);
            string[] headerValueStringArray = headerValueString.Split(':');
            string username = headerValueStringArray[0];
            string password = headerValueStringArray[1];

            //4. Kullanıcı adı ve şifre doğru mi?
            if (username != "admin" || password != "admin")
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid username or password"));
            }

            //5. Kullanıcı adı ve şifre doğru olduğu için kimliğini doğrulayalım.
            var claims = new[] { 
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "admin")
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            
            return Task.FromResult(AuthenticateResult.Success(ticket));


        }

    }
}
