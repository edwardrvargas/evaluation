(function () {
    'use strict';

    angular
        .module('app')
        .controller('desempennoCtrl', ['$scope', 'dataServices', '$mdDialog', function ($scope, dataServices, $mdDialog ) {

            $scope.monthBeg = "";
            $scope.annoBeg = "";

            $scope.monthEnd = "";
            $scope.annoEnd = "";
            //[
            //    { key: 1, value: "ENERO" },
            //    { key: 2, value: "FEBRERO" },
            //    { key: 3, value: "MARZO" },
            //    { key: 4, value: "ABRIL" },
            //    { key: 5, value: "MAYO" },
            //    { key: 6, value: "JUNIO" },
            //    { key: 7, value: "JULIO" },
            //    { key: 8, value: "AGOSTO" },
            //    { key: 9, value: "SEPTIEMBRE" },
            //    { key: 10, value: "OCTUBRE" },
            //    { key: 11, value: "NOVIMEBRE" },
            //    { key: 12, value: "DICIEMBRE" }
            //];                    

            //$scope.monthsBeg2 = ['ENERO', 'FEBRERO', 'MARZO', 'ABRIL', 'MAYO', 'JUNIO', 'JULIO', 'AGOSTO'];  

            //$scope.yearsBeg = [
            //    { key: 2003, value: "2003" },
            //    { key: 2004, value: "2004" },
            //    { key: 2005, value: "2005" },
            //    { key: 2006, value: "2006" },
            //    { key: 2007, value: "2007" }
            //];

            //$scope.monthsEnd = [
            //    { key: 1, value: "ENERO" },
            //    { key: 2, value: "FEBRERO" },
            //    { key: 3, value: "MARZO" },
            //    { key: 4, value: "ABRIL" },
            //    { key: 5, value: "MAYO" },
            //    { key: 6, value: "JUNIO" },
            //    { key: 7, value: "JULIO" },
            //    { key: 8, value: "AGOSTO" },
            //    { key: 9, value: "SEPTIEMBRE" },
            //    { key: 10, value: "OCTUBRE" },
            //    { key: 11, value: "NOVIMEBRE" },
            //    { key: 12, value: "DICIEMBRE" }
            //];

            //$scope.yearsEnd = [
            //    { key: 2003, value: "2003" },
            //    { key: 2004, value: "2004" },
            //    { key: 2005, value: "2005" },
            //    { key: 2006, value: "2006" },
            //    { key: 2007, value: "2007" }
            //];

            $scope.consultors = [];
            $scope.selectedConsultors = [];
            $scope.listGanancias = [];
            //$scope.begDate = new Date();
            //$scope.endDate = new Date();

            //$scope.data = {
            //    date: new Date()
            //};


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
