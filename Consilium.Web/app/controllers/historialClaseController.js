app.controller('historialClaseController', function ($scope, $location, $log, claseDataService) {
    $scope.claseBusqueda = {
        colegioId: 5
    };

    $scope.clases = [];
    $scope.areas = [];
    $scope.usuarios = [];
    $scope.niveles = [];
    $scope.grados = [];

    init();

    function init() {
        obtenerNiveles();
        obtenerAreas();
        obtenerUsuarios();
    }

    function obtenerNiveles() {
        claseDataService.niveles().then(function (resultado) {
            $scope.niveles = resultado.data;
        });
    }
    function obtenerUsuarios() {
        claseDataService.usuarios($scope.claseBusqueda.colegioId).then(function (resultado) {
            $scope.usuarios = resultado.data;
        });
    }
    function obtenerAreas() {
        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
        });
    }

    $scope.obtenerGrados = function () {
        claseDataService.grados($scope.selectedNivel).then(function (resultado) {
            $scope.grados = resultado.data;
        });
    }


    $scope.obtenerHistorialClase = function() {
        claseDataService.clases($scope.claseBusqueda).then(function (results) {
            $scope.clases = results.data;

        }, function (error) {
            alert(error.message);
        });
    }
    $scope.editarClase = function(claseId){
        $location.path("/clase/" + claseId);
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