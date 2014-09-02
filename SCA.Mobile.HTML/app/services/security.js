(function () {
    'use strict';



    ///////Authorization Service
    var serviceId = 'AuthService';
    angular.module('app').factory('AuthService', ['common', AuthService]);


    function AuthService() {
        return {
            isAuthenticated: function () {
                var profile = null;//dataservice.getUserProfile();
                if (profile== null) {
                    return false;
                } else {
                    return true;
                }
            }
        };
    }



    //function AuthService() {
    //    var userIsAuthenticated = false;



    //    this.setUserAuthenticated = function (value) {
    //        userIsAuthenticated = value;
    //    };

    //    this.getUserAuthenticated = function () {
    //        return userIsAuthenticated;
    //    };

    //    return this;
    //}




    ///////Login Service
    angular.module('app').factory('LoginService', ['$scope', '$http', '$window', 'common', 'AuthService', LoginService]);



    function LoginService($scope, $http, $window, common, AuthService) {
        this.attemptLogin = function (user, password) {
            var user = { username: user, password: password };
            $http.post('/token', $scope.user)
     .success(function (data, status, headers, config) {
         $window.sessionStorage.token = data.token;
         $scope.message = 'Welcome';
     })
     .error(function (data, status, headers, config) {
         // Erase the token if the user fails to log in
         delete $window.sessionStorage.token;

         // Handle login errors here
         $scope.message = 'Error: Invalid user or password';
     });
            return true;

        };

        $scope.logout = function () {
            $scope.welcome = '';
            $scope.message = '';
            $scope.isAuthenticated = false;
            delete $window.sessionStorage.token;
        };

        return this;
    }




   


})();