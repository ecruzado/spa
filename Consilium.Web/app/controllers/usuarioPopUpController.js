app.controller('usuarioPopUpController', function ($scope, $modalInstance,usuarioDataService,colegioDataService, usuarioSeleccion) {
    $scope.usuario = {
        nombre: '',
        apellidoPaterno: '',
        apellidoMaterno: '',
        correo: '',
        estado: false,
        disenoClase: false,
        historialClase: false,
        reporte: false,
        mantenimiento: false,
        administrador: false
    };
    $scope.colegios = [];

    init();
    function init() {
        usuarioDataService.usuario(usuarioSeleccion).then(function (resultado) {
            $scope.usuario = resultado.data;
        });
        colegioDataService.colegios().then(function (resultado) {
            $scope.colegios = resultado.data;
        });
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