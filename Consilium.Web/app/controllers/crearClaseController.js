app.controller('crearClaseController', function ($scope, $location, $log, $routeParams,$filter, toaster,
    usuarioSesion, claseDataService) {
    $scope.claseCabecera = {
        areaId: $routeParams.area,
        nombreArea: $routeParams.nombreArea,
        claseId: 0,
        nivelId: 0,
        gradoId: 0,
        titulo: '',
        colegioId: usuarioSesion.getUsuario().colegioId,
        usuario: usuarioSesion.getUsuario().codigo
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
            claseDataService.grados($scope.claseCabecera.nivelId).then(function (resultado) {
                $scope.grados = resultado.data;
            });
        });
    }

    $scope.obtenerGrados = function () {
        claseDataService.grados($scope.claseCabecera.nivelId).then(function (resultado) {
            $scope.grados = resultado.data;
        });
    }

    $scope.crearClase = function () {
        $scope.claseCabecera.fechaInicioFormato = $filter('date')($scope.claseCabecera.fechaInicioFormato, 'dd/MM/yyyy'),
        $scope.claseCabecera.fechaFinFormato = $filter('date')($scope.claseCabecera.fechaFinFormato, 'dd/MM/yyyy'),

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