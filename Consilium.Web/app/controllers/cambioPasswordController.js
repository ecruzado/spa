app.controller('cambioPasswordController', function ($scope, $modalInstance, usuarioDataService, usuarioSeleccion) {
    $scope.usuario = {};
    init();
    function init() {
        if (usuarioSeleccion != 0) {
            usuarioDataService.usuario(usuarioSeleccion).then(function (resultado) {
                $scope.usuario = resultado.data;
            });
        }
    };

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardar = function () {
        usuarioDataService.cambioPassword($scope.usuario).then(function () {
            $modalInstance.close();
        })
    };
});