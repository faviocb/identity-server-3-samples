(function () {
    "use strict";

    angular.module("common.services",
                    ["ngResource"])
      	.constant("appSettings",
        {
            tripGalleryAPI: "https://localhost:44315" 
        });




    //oidc manager for dep injection

    angular.module("common.services")
        .factory("OidcManager", function () {



            //configure manager

            var config = {

                client_id: "tripgalleryimplicit",
                redirect_uri: "https://localhost:44301/callback.html",
                response_type: "id_token token",//response_type: "id_token",
                scope: "openid profile address", //scope: "openid profile",
                authority: "https://localhost:44300/identity"

            };


            var mgr = new OidcTokenManager(config);


            return {
                OidcTokenManager: function () {

                    return mgr;
                }
            };






        });





}());
