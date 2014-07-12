app.controller('crearClaseController', function ($scope, $location, $log, $routeParams, claseDataService) {
    $scope.claseCabecera = {
        colegioId: 5,
        areaId: $routeParams.area,
        nombreArea: $routeParams.nombreArea,
        claseId: 4481,
        nivelId: 1,
        gradoId: 2,
        nombreClase:''
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
        $location.path("/clase/150");
    }
});