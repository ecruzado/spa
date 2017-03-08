app.controller('historialClaseController', function ($scope, $location, $filter, $log,$modal,
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
            usuarioSesion.busqueda = $scope.claseBusqueda;

            claseDataService.clases($scope.claseBusqueda).then(function (results) {
                $scope.clases = results.data;

            }, function (error) {
                alert(error.message);
            });
        });

    }

    init();

    function init() {
        if (!isEmpty(usuarioSesion.busqueda)) {
            $scope.claseBusqueda = usuarioSesion.busqueda;
            $scope.obtenerGrados();
            $scope.obtenerHistorialClase();
        }
        
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
        claseDataService.areas(usuarioSesion.getUsuario().colegioId).then(function (resultado) {
            $scope.areas = resultado.data;
            $scope.areas.splice(0, 0, { areaId: 0, descripcion: '--Seleccionar Area--' });
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

    $scope.eliminarClase = function (claseId) {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/eliminarClasePopUpView.html?v=2',
            controller: 'eliminarClasePopUpController',
            size: 'sm',
            resolve: {
            }
        });
        modalInstance.result.then(function (resultado) {
            if (resultado) {
                claseDataService.deleteClase(claseId).then(function () {
                    $scope.obtenerHistorialClase();
                });

            }
        });
    };

    $scope.copiarClase = function (claseId) {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/copiarClasePopUpView.html',
            controller: 'copiarClasePopUpController',
            resolve: {
            }
        });
        modalInstance.result.then(function (claseCopiar) {
            var nuevaClaseCopiar = claseCopiar;
            nuevaClaseCopiar.claseIdOrigen = claseId;
            nuevaClaseCopiar.colegioId = usuarioSesion.getUsuario().colegioId;
            nuevaClaseCopiar.usuario = usuarioSesion.getUsuario().codigo;
            claseDataService.copiarClase(nuevaClaseCopiar).then(function (resultado) {
                $location.path("/clase/" + resultado.data);
            });
        });
    }

    //function helper
    function isEmpty(obj) {
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop))
                return false;
        }

        return true;
    }
});