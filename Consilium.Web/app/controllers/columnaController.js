app.controller('columnaController', function ($scope, $location, $log, $routeParams, claseDataService, toaster) {
    $scope.areas = [];
    $scope.nodo1 = [];
    $scope.niveles = [];
    $scope.grados = [];
    init();

    function init() {
        obtenerAreas();
    }

    function obtenerAreas() {
        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
        });

    }

    function obtenerNiveles() {
        claseDataService.niveles().then(function (resultado) {
            $scope.niveles = resultado.data;
        });
    }

    $scope.obtenerGrados = function () {
        claseDataService.grados($scope.selectedNivel).then(function (resultado) {
            $scope.grados = resultado.data;
        });
    }


});