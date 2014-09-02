(function () {
    'use strict';

    var controllerId = 'topnav';
    angular.module('app').controller(controllerId, ['$rootScope', 'common', topnav]);

    function topnav($rootScope, common) {
        var vm = this;
        var logSuccess = common.logger.getLogFn(controllerId, 'success');
        vm.isLoggedIn = false;
        vm.userInfo = {};
        $rootScope.$on('authenticationRequired', function (event, userInfo) {
            console.log('handled authenticated event by topnav!!');
            vm.userInfo = userInfo;
            vm.isLoggedIn = true;
            console.log('Name from topnav is: ' + userInfo.namear);
        });
    }//end function

});