app.controller('crearClaseController', function ($scope, $location, $log, $routeParams, claseDataService, toaster) {
    $scope.claseCabecera = {
        colegioId: 5,
        areaId: $routeParams.area,
        nombreArea: $routeParams.nombreArea,
        claseId: 4481,
        nivelId: 1,
        gradoId: 2,
        titulo: ''
    };
    $scope.niveles = [];
    $scope.grados = [];
    init();

    function init() {
        obtenerNiveles();
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

    $scope.crearClase = function () {
        claseDataService.saveClase($scope.claseCabecera).then(function (resultado) {
            $location.path("/clase/"+resultado.data.claseId);
        }, function (resultadoError) {
            toaster.pop('error', "Ocurrio un error", "Ocurrido un error, no se pudo completar la operacion");
        });
    }

    $scope.openFechaInicio = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.openedFechaInicio = true;
    };
    $scope.openFechaFin = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.openedFechaFin = true;
    };

});