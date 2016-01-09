(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("tokenContainer", [tokenContainer])


    function tokenContainer() {


        //debugger;


        

        var container = { token: "" };


        var setToken = function (token) {
            container.token = token;
        };

        
        var getToken = function () {

        
            if (container.token === "") {

        
                if (localStorage.getItem("access_token") === null) {

        
                    // get the token through an in-app, non-redirection based flow
                    // we show the login screen
                    window.location.href = "#/login";


                    ////get the token using implicit flow

                    //var url = "https://localhost:44300/identity/connect/authorize?" +
                    //            "client_id=tripgalleryimplicit&" +
                    //            "redirect_uri=" + encodeURI(window.location.protocol + "//" + window.location.host + "/callback.html") + "&" +
                    //            "response_type=token&" +
                    //            "scope=gallerymanagement";

                    //window.location = url;


                }
                else {
                    //
                    setToken(localStorage["access_token"])

                    
                }

                
            }

            return container;
        };




        return {
            getToken: getToken
        };


    };


})();
