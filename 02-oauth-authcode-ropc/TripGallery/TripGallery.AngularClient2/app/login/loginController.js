(function () {
    "use strict";
    angular
        .module("tripGallery")
        .controller("loginController",
                     ["$http", LoginController]);




            function LoginController($http) {

                var vm = this;

                vm.loginError = "";
                vm.credentials = {
                    username: "",
                    password: ""
                };



                vm.submit = function(){
    
                    vm.loginError = "";

                    var dataForBody = "grant_type=password&" +
                                        "username=" + encodeURI(vm.credentials.username) + "&" +
                                        "password=" + encodeURI(vm.credentials.password) + "&" +
                                        "scope=" + encodeURI("gallerymanagement");



                    var encodedClientIdAndSecret = btoa("tripgalleryropc:myrandomclientsecret");


                    var messageHeader = {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'Authorization': 'Basic ' + encodedClientIdAndSecret
                    };


                    return $http({

                        method: 'POST',
                        url: "https://localhost:44300/identity/connect/token",
                        headers: messageHeader,
                        data: dataForBody

                    }).success(function (data) {


                        localStorage["access_token"] = data.access_token;

                        // clear un/pw

                        vm.credentials.username = "";
                        vm.credentials.password = "";


                        // redirect to root
                        window.location = window.location.protocol + "//" + window.location.host + "/";



                    }).error(function (data) {


                        vm.loginError = data.error;


                        vm.credentials.username = "";
                        vm.credentials.password = "";


                    });


    
                }

            }

}());
