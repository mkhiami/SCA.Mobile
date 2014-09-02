(function () {
    'use strict';
    

    
    var app = angular.module('app', [
        // Angular modules 
        'ngAnimate',        // animations
        'ngRoute',          // routing
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)
        'pascalprecht.translate',//angular-translate
        // Custom modules 
        'common',           // common functions, logger, spinner
        'common.bootstrap', // bootstrap dialog wrapper functions
        'webStorageModule',
        // 3rd Party Modules
        'ui.bootstrap'      // ui-bootstrap (ex: carousel, pagination, dialog)
    ]);

    // Including ngTranslate

    app.config(['$translateProvider', function ($translateProvider) {
      //  $translateProvider.useUrlLoader('/this/doesnt/matter');
        $translateProvider.useStaticFilesLoader({
            prefix: '/content/strings',
            suffix: '.json'
        });

      $translateProvider.preferredLanguage('ar');
  }]);
    app.factory('authInterceptor', function ($rootScope, $q, dataService) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
               
                if (dataService.isAuthenticated())
                {
                    config.headers.Authorization = 'Bearer ' + dataService.getToken();
                    console.log('Interceptor Token: '+dataService.getToken());
                }
                //if ($window.sessionStorage.token) {
                //    config.headers.Authorization = 'Bearer ' + $window.sessionStorage.token;
                //}
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    alert('invalid username');
                }
                return $q.reject(rejection);
            }
        };
    });
    
    // Handle routing errors and success events
    app.run(['$route', '$rootScope', '$location', 'dataService', 'userAccountService', function ($route, $rootScope, $location, dataService, userAccountService) {

       

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            console.log('URL:' + next.templateUrl + ' Login Required? ' + next.requireLogin + ' is logged in? ' + dataService.isAuthenticated());

            //console.log('entered login funtion(' + AuthService.isAuthenticated);//+ ' is authenticated? ' + AuthService.getUserAuthenticated()
            // if you're logged out send to login page.
            if (next.requireLogin && !dataService.isAuthenticated()) {
                console.log('Should Redirect');

              $location.url('/login');
                //$rootScope.$apply(function () {
                 //   $location.path('/login');
                //});
                event.preventDefault();
            }
        });


        
    }]);
})();
        //$rootScope.$on("$locationChangeStart", function (event, next, current) {
        //    console.log('location start'+ window.routes);
        //    for (var i in window.routes) {
        //        if (next.indexOf(i) != -1) {
        //            console.log('entered login funtion(' + AuthService.isAuthenticated);
                  
        //            if (window.routes[i].next.requireLogin && !AuthService.isAuthenticated) {
        //                alert("You need to be authenticated to see this page!");
        //                event.preventDefault();
        //            }
        //        }
        //    }
        //});
