(function () {
    'use strict';

    angular
        .module('app')
        .controller('desempennoCtrl', ['$scope', 'dataServices', '$mdDialog', '$http', function ($scope, dataServices, $mdDialog, $http ) {
            $scope.cities = [];
            $scope.consultors = [];
            $scope.selectedConsultors = [];
            $scope.listGanancias = [];
            $scope.begDate = new Date();
            $scope.endDate = new Date();

            $scope.data = {
                date: new Date()
            };


            getData();
         
            function getData() {
                dataServices.getConsultors().then(function(result) {
                    $scope.consultors = result;
                });
            }

            function getGanancia() {
                var data = {};
                data.consultors = "";
                data.begmonth = 1;  //$scope.begDate.getMonth();
                data.endmonth = 1; // $scope.endDate.getMonth();
                data.anno = 2007;   //$scope.begDate.getYear();
                var consultors = "";
                angular.forEach($scope.selectedConsultors, function (value, key) {
                    if (key === 0)
                        data.consultors = value.IdUsuario;
                    else
                        data.consultors = data.consultors.concat(";", value.IdUsuario);
                });

                dataServices.getGanancias(data).then(function (result) {
                    $scope.listGanancias = result;
                });
            }


            $scope.selectAll = function () {
                $scope.selectedConsultor = [];
                angular.forEach($scope.consultors, function (value, key) {
                    value.Selected = false;
                    $scope.selectedConsultor.push(value);
                });
                $scope.consultors = [];

                if ($(".btnSelect").text() === "Todos")
                    $(".btnSelect").text("Ninguno");
                else {
                    $(".btnSelect").text("Todos");
                    getData();
                }                    
            };

            $scope.selected = function () {              
                var index = 0;

                //NOTE: Se realiza de esta forma ya que la coleccion cambia.
                angular.forEach($scope.consultors, function (value, key) {
                    if (value.Selected) {
                        value.Selected = false;
                        $scope.selectedConsultors.push(value);                        
                    }                    
                });
                angular.forEach($scope.consultors, function (value, key) {
                    if ($scope.consultors[key].Selected) {
                        $scope.consultors.splice(key, 1);
                    }
                });
            };

            $scope.removed = function () {
                var index = 0;
                angular.forEach($scope.selectedConsultors, function (value, key) {
                    if (value.Selected) {
                        value.Selected = false;
                        $scope.consultors.push(value);                           
                    }
                });
                angular.forEach($scope.selectedConsultors, function (value, key) {
                    if ($scope.selectedConsultors[key].Selected) {
                        $scope.selectedConsultors.splice(key, 1);
                    }
                });
            };

            $scope.ganancias = function () {
                $(".tblGrafico").hide();
                $(".tblGanancia").hide();
                if ($scope.selectedConsultors.length === 0) {
                    $mdDialog.show(
                        $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#popupContainer')))
                        .clickOutsideToClose(true)
                        .title('Ooop!!!')
                        .textContent('Por favor, verifique su selección de Consultores.')
                        .ok('Ok')
                    );
                    return;
                }
                getGanancia();
                $(".tblGanancia").show();
            };

            $scope.grafico = function() {
                $(".tblGrafico").hide();
                $(".tblGanancia").hide();
                if ($scope.selectedConsultors.length === 0) {
                    $mdDialog.show(
                        $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#popupContainer')))
                        .clickOutsideToClose(true)
                        .title('Ooop!!!')
                        .textContent('Por favor, verifique su selección de Consultores.')
                        .ok('Ok')
                    );
                    return;
                }
                var paramData = {};
                paramData.consultorId = "13519958";
                paramData.mes = 1;
                paramData.anno = 2018;
                getGanancia(paramData);
                var values = [];
                angular.forEach($scope.listGanancias, function (value, key) {
                    var item = {};
                    item.y = value.consultor;
                    item.a = value.totalreceitaliquida;
                    values.push(item);
                });
                var data = [
                        { y: '2014', a: 50, b: 90 },
                        { y: '2015', a: 65, b: 75 },
                        { y: '2016', a: 50, b: 50 },
                        { y: '2017', a: 75, b: 60 },
                        { y: '2018', a: 80, b: 65 },
                        { y: '2019', a: 90, b: 70 },
                        { y: '2020', a: 100, b: 75 },
                        { y: '2021', a: 115, b: 75 },
                        { y: '2022', a: 120, b: 85 },
                        { y: '2023', a: 145, b: 85 },
                        { y: '2024', a: 160, b: 95 }
                    ],
                    config = {
                        data: data,
                        xkey: 'consultor',
                        ykeys: ['totalreceitaliquida'],
                        labels: [],
                        fillOpacity: 0.6,
                        hideHover: 'auto',
                        behaveLikeLine: true,
                        resize: true,
                        pointFillColors: ['#ffffff'],
                        pointStrokeColors: ['black'],
                        lineColors: ['gray', 'red']
                    };
                config.element = 'bar-chart';
                Morris.Bar(config);
                $(".tblGrafico").show();
            };
        }]);


})();
