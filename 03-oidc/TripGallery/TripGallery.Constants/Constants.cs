
namespace TripGallery
{
    public class Constants
    {

        public const string TripGalleryAPI = "https://localhost:44315/";
        public const string TripGalleryMVC = "https://localhost:44318/";
        public const string TripGalleryMVCSTSCallback = "https://localhost:44318/stscallback";
        public const string TripGalleryAngular = "https://localhost:44301/";


        public const string TripGalleryClientSecret = "myrandomclientsecret";
        public const string TripGalleryIssuerUri = "https://tripcompanysts/identity";
        public const string TripGallerySTSOrigin = "https://localhost:44300"; // should match the Identity Server PORT number
        public const string TripGallerySTS = TripGallerySTSOrigin + "/identity"; // ? should match the configuration in the identity service start up?
        public const string TripGallerySTSTokenEndpoint = TripGallerySTS + "/connect/token";
        public const string TripGallerySTSAuthorizationEndpoint = TripGallerySTS + "/connect/authorize";
        public const string TripGallerySTSUserInfoEndpoint = TripGallerySTS + "/connect/userinfo";
        public const string TripGallerySTSEndSessionEndpoint = TripGallerySTS + "/connect/endsession";
        public const string TripGallerySTSRevokeTokenEndpoint = TripGallerySTS + "/connect/revocation";


    }

}
