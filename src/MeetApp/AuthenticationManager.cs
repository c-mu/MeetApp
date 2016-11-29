using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace MeetApp
{
    public class AuthenticationManager
    {
        static readonly AuthenticationManager instance = new AuthenticationManager();

        static string clientId;

        private AuthenticationManager() { }

        public static AuthenticationManager GetInstance(string clientId)
        {
            AuthenticationManager.clientId = clientId;
            return instance;
        }

        public async Task Authenticate()
        {
            var redirectUrl = "https://www.meetup.com";
            var requestUri = new Uri($"https://secure.meetup.com/oauth2/authorize?client_id={clientId}&response_type=token&redirect_uri={redirectUrl}");
            var callbackUri = new Uri(redirectUrl);
            var authenticationResponse = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, requestUri, callbackUri);
            IsAuthenticated = authenticationResponse.ResponseStatus == WebAuthenticationStatus.Success ? true : false;
            if (IsAuthenticated)
            {
                var responseQuery = new Uri(authenticationResponse.ResponseData).Fragment.Substring(1);
                var queryParams = responseQuery.Split('&');
                AccessToken = queryParams.First(qp => qp.StartsWith("access_token", StringComparison.OrdinalIgnoreCase)).Split('=')[1];
            }
        }

        public bool IsAuthenticated { get; private set; }

        public string AccessToken { get; private set; }

    }
}
