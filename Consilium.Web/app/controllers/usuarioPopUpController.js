app.controller('usuarioPopUpController', function ($scope, $modalInstance, usuarioDataService,
    colegioDataService, usuarioSeleccion) {
    $scope.usuario = {
        codigo: '',
        nombre: '',
        apellidoPaterno: '',
        apellidoMaterno: '',
        correo: '',
        estado: true,
        disenoClase: false,
        historialClase: false,
        reporte: false,
        mantenimiento: false,
        administrador: false,
        eliminarClase: false,
    };
    $scope.colegios = [];
    $scope.disabledUsuario = true;
    init();
    function init() {
        colegioDataService.colegios().then(function (resultado) {
            $scope.colegios = resultado.data;
        });

        if (usuarioSeleccion != 0) {
            usuarioDataService.usuario(usuarioSeleccion).then(function (resultado) {
                $scope.usuario = resultado.data;
            });
        } else {
            $scope.disabledUsuario = false;
        }
    };

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        usuarioDataService.saveUsuario($scope.usuario).then(function () {
            $modalInstance.close();
        })
    };
});