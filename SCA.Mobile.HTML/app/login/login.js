(function () {
    'use strict';
    var controllerId = 'LoginCtrl';
    angular.module('app').controller(controllerId, ['$scope', '$location', 'userAccountService', '$translate', 'webStorage', LoginController]);

    function LoginController($scope, $location, userAccountService, $translate, webStorage) {
        var vm = this;
        vm.loginUser = loginUser;
        vm.isLoggedIn = false;
        vm.userData = {
            UserName: "",
            Password: "" 
        };



        function loginUser() {
            userAccountService.loginUser(vm.userData).then(function (data) {
                vm.isLoggedIn = true;
                vm.userName = data.UserName;
               
                vm.bearerToken = data.access_token;
                userAccountService.getProfile();
                
                $location.path('/dashboard');
            }, function (error, status) {
                vm.isLoggedIn = false;
                console.log(status);
            });
        }
    }///end login controller
})();