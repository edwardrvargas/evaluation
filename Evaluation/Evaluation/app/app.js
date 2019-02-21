(function () {
    'use strict';

    angular.module('app',
            [
                'ngRoute', 'ngMaterial', 'ngMessages','ngSanitize'
            ])
        .config([
            '$routeProvider', '$locationProvider', '$qProvider', function ($routeProvider, $locationProvider, $qProvider) {
                $locationProvider.hashPrefix('');
                $routeProvider
                    .when('/',
                        {
                            controller: 'desempennoCtrl',
                            templateUrl: '/app/templates/desempenno.html'
                        })
                    .otherwise({ redirectTo: '/' });
                $qProvider.errorOnUnhandledRejections(false); 
            }
        ]);
})();