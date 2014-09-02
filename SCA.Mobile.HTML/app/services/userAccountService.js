(function () {
    'use strict';
    var serviceId = 'userAccountService';
    angular.module('app').factory(serviceId, ['$http', '$q', '$rootScope', 'dataService', userAccountService]);

    function formEncode(obj) {
        var encodedString = '';
        for (var key in obj) {
            if (encodedString.length !== 0) {
                encodedString += '&';
            }

            encodedString += key + '=' + encodeURIComponent(obj[key]);
        }
        return encodedString.replace(/%20/g, '+');
    }
    function userAccountService($http, $q, $rootScope, dataService) {
        // Define the functions and properties to reveal.
        var service = {
         
            loginUser: loginUser,
            getProfile: getProfile,
        };
        var serverBaseUrl = "http://mobile.sca.ae";

        return service;
        //$rootScope.isAuthenticated = false;
        //$rootScope.accessToken = "";
        //$rootScope.userName = "";
        //$rootScope.userInfo = null;
        var isAuthenticated = false;
        var userName, accessToken = "";

        function loginUser(userData) {
            var tokenUrl = serverBaseUrl + "/Token";
            if (!userData.grant_type) {
                userData.grant_type = "password";
            }
           
            var deferred = $q.defer();
            $http.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";
            $http({
                method: 'POST',
                url: tokenUrl,
                data: formEncode(userData),
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            }).success(function (data, status, headers, cfg) {
                console.log(JSON.stringify(data));
                dataService.setToken(data.accesstoken, data.username);


                //$rootScope.isAuthenticated =  isAuthenticated= true;
                //$rootScope.userName = userName = userData.userName;
                //$rootScope.accessToken = accessToken=  data.access_token;
           
                deferred.resolve(data);
            }).error(function (err, status) {
                $rootScope.isAuthenticated = false;
                console.log(err);
                deferred.reject(status);
            });
            return deferred.promise;
        }
        function getProfile() {
            var url = serverBaseUrl + "/account/profile";
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: url,
               // headers: getHeaders(),
            }).success(function (data, status, headers, cfg) {
                console.log(data);
                $rootScope.userInfo = data;
                console.log(JSON.stringify(data));
                dataService.setInfo(data);
                $rootScope.$broadcast('authenticationRequired',data);

                console.log($rootScope.userInfo);
                deferred.resolve(data);
            }).error(function (err, status) {

                console.log($rootScope.accessToken + err);
                deferred.reject(status);
            });
            return deferred.promise;
        }
        // we have to include the Bearer token with each call to the Web API controllers. 
        function getHeaders() {
            console.log("Authorization" + "---" + "Bearer " + dataService.getToken());
            if (accessToken) {
                return { "Authorization": "Bearer " + accessToken };
            }
        }
    }
})();