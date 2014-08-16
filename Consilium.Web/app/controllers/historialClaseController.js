app.controller('historialClaseController', function ($scope, $location, $filter, $log,
    usuarioSesion, claseDataService,usuarioDataService) {
    $scope.claseBusqueda = {
        colegioId: usuarioSesion.getUsuario().colegioId,
        areaId: 0,
        usuario: usuarioSesion.getUsuario().codigo,
        nivelId: 0,
        gradoId: 0
    };

    $scope.clases = [];
    $scope.areas = [];
    $scope.usuarios = [];
    $scope.niveles = [];
    $scope.grados = [{gradoId:0,gradoDesc:'--Seleccionar Grado--'}];

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
        usuarioDataService.usuarios($scope.claseBusqueda.colegioId).then(function (resultado) {
            $scope.usuarios = resultado.data;
            $scope.usuarios.splice(0,0,{ codigo: '--Seleccionar Usuario--' });
        });
    }
    function obtenerAreas() {
        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
            $scope.areas.splice(0, 0, { areaId: 0, descripcion: '--Seleccionar Area--' });
        });
    }

    $scope.obtenerGrados = function () {
        claseDataService.grados($scope.claseBusqueda.nivelId).then(function (resultado) {
            $scope.claseBusqueda.gradoId = 0;
            $scope.grados = resultado.data;
        });
    }


    $scope.obtenerHistorialClase = function () {
        usuarioSesion.verificarUsuario().then(function () {
            $scope.claseBusqueda.fechaInicioFormato = $filter('date')($scope.claseBusqueda.fechaInicioFormato, 'dd/MM/yyyy'),
            $scope.claseBusqueda.fechaFinFormato = $filter('date')($scope.claseBusqueda.fechaFinFormato, 'dd/MM/yyyy'),

            claseDataService.clases($scope.claseBusqueda).then(function (results) {
                $scope.clases = results.data;

            }, function (error) {
                alert(error.message);
            });
        });

    }
    $scope.limpiar = function () {
        $scope.claseBusqueda.colegioId = 5;
        $scope.claseBusqueda.areaId = 0;
        $scope.claseBusqueda.usuario = '--Seleccionar Usuario--';
        $scope.claseBusqueda.nivelId = 0;
        $scope.claseBusqueda.gradoId = 0;
        $scope.claseBusqueda.fechaInicioFormato = '';
        $scope.claseBusqueda.fechaFinFormato = '';

    }
    $scope.editarClase = function (claseId) {
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