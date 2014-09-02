(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);



    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
          
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });



    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'dashboard',
                    requireLogin: true,
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> الصفحة الرئيسية',
                        requireLogin: true
                    }
                }
            },
            {
                url: '/login',
                config: {
                    title: 'login',
                    templateUrl: 'app/login/login.htm',
                    requireLogin: false,
                    settings: {
                        requireLogin: false
                    }
                }
            },
            {
                url: '/correspondence',
                config: {
                    title: 'Correspodences',
                    controller: 'correspondencesCtrl', 
                    templateUrl: 'app/correspondence/correspondences.htm',
                    requireLogin: true,
                    settings: {
                        nav: 2,
                        content: "<i class='fa fa-list-alt'></i> المراسلات",
                        requireLogin: true
                     
                    }
                }
            },

             {
                 url: '/correspondence/:id',
                 config: {
                     title: 'Correspondence Details',
                     controller: 'correspondencesCtrl',
                     templateUrl: 'app/correspondence/correspondence.htm',
                     
                 }
             },



            {
                url: '/task',
                config: {
                    title: 'tasks',
                    templateUrl: 'app/task/tasks.htm',
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-tasks"></i> المهام',
                        requireLogin: true
                    }
                }
            }
        ];
        $routeProvider.otherwise({
            redirectTo: '/login'
        });
    }
})();