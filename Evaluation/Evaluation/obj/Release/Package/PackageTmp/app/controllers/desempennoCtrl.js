(function () {
    'use strict';

    angular
        .module('app')
        .controller('desempennoCtrl', ['$scope', 'dataServices', '$mdDialog', function ($scope, dataServices, $mdDialog ) {

            $scope.monthBeg = "";
            $scope.annoBeg = "";

            $scope.monthEnd = "";
            $scope.annoEnd = "";
            $scope.consultors = [];
            $scope.selectedConsultors = [];
            $scope.listGanancias = [];
            getData();
         
            function getData() {
                dataServices.getConsultors().then(function(result) {
                    $scope.consultors = result;
                });
            }

            function getGanancia() {
                var data = {};
                data.consultors = "";

                data.begmonth = $scope.getMonthIndex($('.monthBeg').text());  
                data.endmonth = $scope.getMonthIndex($('.monthEnd').text());
                data.beganno = $('.annoBeg').text();  
                data.endanno = $('.annoEnd').text();     
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
                angular.forEach($scope.consultors,function(value, key) {
                    value.Selected = $(".btnSelect").text() === "Todos";
                });
                if ($(".btnSelect").text() === "Todos")
                    $(".btnSelect").text("Ninguno");
                else 
                    $(".btnSelect").text("Todos");
            };

            $scope.selected = function () {
                var auxSelected = [];
                var auxAvailable = [];
                angular.forEach($scope.consultors, function (value, key) {
                    if ($scope.consultors[key].Selected) {
                        value.Selected = false;
                        auxSelected.push(value);
                    } else {
                        auxAvailable.push($scope.consultors[key]);
                    }
                });
                $scope.consultors = auxAvailable;
                $scope.selectedConsultors = $scope.selectedConsultors.concat(auxSelected);
            };

            $scope.removed = function () {
                var auxSelected = [];
                var auxAvailable = [];
                angular.forEach($scope.selectedConsultors, function (value, key) {
                    if ($scope.selectedConsultors[key].Selected) {
                        value.Selected = false;
                        auxSelected.push(value);
                    } else {
                        auxAvailable.push($scope.selectedConsultors[key]);
                    }
                });
                $scope.selectedConsultors = auxAvailable;
                $scope.consultors = $scope.consultors.concat(auxSelected); 
            };


            $scope.getMonthIndex = function (monthName) {
                var index = 0;
                switch (monthName) {
                    case "ENERO":
                        index = 1;
                        break;
                    case "FEBRERO":
                        index = 2;
                        break;
                    case "MARZO":
                        index = 3;
                        break;
                    case "ABRIL":
                        index = 4;
                        break;
                    case "MAYO":
                        index = 5;
                        break;
                    case "JUNIO":
                        index = 6;
                        break;
                    case "JULIO":
                        index = 7;
                        break;
                    case "AGOSTO":
                        index = 8;
                        break;
                    case "SEPTIEMBRE":
                        index = 9;
                        break;
                    case "OCTUBRE":
                        index = 10;
                        break;
                    case "NOVIEMBRE":
                        index = 11;
                        break;
                    case "DICIEMBRE":
                        index = 12;
                        break;
                }
                return index;
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

                if ($('.monthBeg').text() === "" || $('.monthBeg').text().includes("Mes") ||
                    $('.annoBeg').text() === "" || $('.annoBeg').text().includes("Año") ||
                    $('.monthEnd').text() === "" || $('.monthEnd').text().includes("Mes") ||
                    $('.annoBeg').text() === "" || $('.annoBeg').text().includes("Año")) { 
                    $mdDialog.show(
                        $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#popupContainer')))
                        .clickOutsideToClose(true)
                        .title('Ooop!!!')
                        .textContent('Por favor, verifique la seleccion del Periodo.')
                        .ok('Ok')
                    );
                    return;
                }

                getGanancia();
                //if ($scope.listGanancias.length === 0) {
                //    $mdDialog.show(
                //        $mdDialog.alert()
                //        .parent(angular.element(document.querySelector('#popupContainer')))
                //        .clickOutsideToClose(true)
                //        .title('Ooop!!!')
                //        .textContent('Parece que no existen datos en el Periodo especificado.')
                //        .ok('Ok')
                //    );
                //    return;
                //}
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
                        .textContent('Por favor, verifique su selección de Consultores y ejecute la Consulta de Ganancia.')
                        .ok('Ok')
                    );
                    return;
                }
                var values = [];
                angular.forEach($scope.listGanancias, function (value, key) {
                    var item = {};
                    item.y = value.consultor;
                    item.a = value.totalreceitaliquida;
                    values.push(item);
                });
                var data = values,
                    config = {
                        data: data,
                        xkey: 'y',
                        ykeys: ['a'],
                        labels: ['Total Venta Liquida'],
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
