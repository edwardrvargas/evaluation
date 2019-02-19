(function () {
    'use strict';

    angular.module('app',
            [
                'ngRoute', 'ngMaterial', 'ngMessages','ngSanitize'
            ])
        .config([
            '$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
                $locationProvider.hashPrefix('');
                $routeProvider
                    .when('/',
                        {
                            controller: 'desempennoCtrl',
                            templateUrl: '/app/templates/desempenno.html'
                        })
                    .otherwise({ redirectTo: '/' });
            }
        ]);
})();