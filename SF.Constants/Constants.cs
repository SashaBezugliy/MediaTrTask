
namespace SF
{
    public class Constants
    {

        public const string SF_API = "https://localhost:44348/";
        public const string SF_MVC = "https://localhost:44318/";
        public const string SF_MVC_STSCallback = "https://localhost:44318/stscallback";
        public const string SF_Angular = "https://localhost:44316/";

        public const string SF_ClientSecret = "myrandomclientsecret";

        public const string SF_IssuerUri = "https://tripcompanysts/identity";
        public const string SF_STSOrigin = "https://localhost:44395";
        public const string SF_STS = SF_STSOrigin + "/identity";
        public const string SF_STSTokenEndpoint = SF_STS + "/connect/token";
        public const string SF_STSAuthorizationEndpoint = SF_STS + "/connect/authorize";
        public const string SF_STSUserInfoEndpoint = SF_STS + "/connect/userinfo";
        public const string SF_STSEndSessionEndpoint = SF_STS + "/connect/endsession";
        public const string SF_STSRevokeTokenEndpoint = SF_STS + "/connect/revocation";


    }

}
