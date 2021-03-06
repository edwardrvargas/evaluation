﻿(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataServices', ['$http', '$q', function($http, $q) {
            var service = {};

            //------------------------------- GETCITIES -----------------------------------//
            service.getCities = function() {
                var deferred = $q.defer();
                $http.get('api/Consultor').then(function (result) {
                    
                    deferred.resolve(result.data);
                }, function() {
                    deferred.reject();
                    });
                return deferred.promise;
            };

            //------------------------------- CONSULTORS -----------------------------------//
            service.getConsultors = function () {
                var deferred = $q.defer();
                $http.get('api/Consultor').then(function (result) {

                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };


            //------------------------------- RECEITAS LIQUIDAS -----------------------------------//
            service.getGanancias = function (param) {
                var deferred = $q.defer();
                $http.get('api/Ganancia?consultors=' + param.consultors + '&beganno=' + param.beganno + '&endanno=' + param.endanno +'&begmonth=' + param.begmonth + '&endmonth=' + param.endmonth).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;                
            };
            return service;
        }]);
    
})();