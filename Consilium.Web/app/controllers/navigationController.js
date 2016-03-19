app.controller('navigationController', function ($scope, $location, usuarioSesion, claseDataService) {
    $scope.disenoClase = false;
    $scope.historialClase = false;
    $scope.reporte = false;
    $scope.mantenimiento = false;
    $scope.administrador = false;
    $scope.areas = [];
    init();

    function init() {
        usuarioSesion.obtenerUsuarioServer().then(function (usuario) {
            $scope.disenoClase = usuario.DisenoClase;
            $scope.historialClase = usuario.HistorialClase;
            $scope.reporte = usuario.Reporte;
            $scope.mantenimiento = usuario.Mantenimiento;
            $scope.administrador = usuario.Administrador;


            claseDataService.claseComentarios(0, usuarioSesion.getUsuario().codigo).then(function (resultado) {
                $scope.comentarios = resultado.data;
            });
        });

        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
        });

    }

    $scope.isActive = function (path) {
        return $location.path().substr(0, path.length) == path;
    };

});