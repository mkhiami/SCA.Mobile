(function () { 
    'use strict';
    
    var controllerId = 'shell';
    angular.module('app').controller(controllerId,
        ['$rootScope', 'common', 'config', 'dataService', shell]);

    function shell($rootScope, common, config, dataService) {
        var vm = this;
        var logSuccess = common.logger.getLogFn(controllerId, 'success');
        var events = config.events;
        vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;
        vm.isLoggedIn = true;
        vm.userInfo = {};
        vm.spinnerOptions = {
            radius: 40,
            lines: 7,
            length: 0,
            width: 30,
            speed: 1.7,
            corners: 1.0,
            trail: 100,
            color: '#F58A00'
        };

        activate();

        function activate() {
            logSuccess('Mobile Site Loaded!', null, true);
            vm.isLoggedIn = dataService.getToken() != null;
            vm.userInfo = dataService.getInfo();

            common.activateController([], controllerId);
        }

        function toggleSpinner(on) { vm.isBusy = on; }

        $rootScope.$on('$routeChangeStart',
            function (event, next, current) { toggleSpinner(false); }
        );

        $rootScope.$on('authenticationRequired', function (event, userInfo) {
            console.log('handled authenticated event!!' + userInfo);
            vm.userInfo = userInfo;
            vm.isLoggedIn = true;
            console.log('Name is: '+userInfo.namear);
        });

        
        $rootScope.$on(events.controllerActivateSuccess,
            function (data) { toggleSpinner(false); }
        );

        $rootScope.$on(events.spinnerToggle,
            function (data) { toggleSpinner(data.show); }
        );
    };
})();