app.controller('exportarColegioPopUpController', function ($scope, $modalInstance, colegioDataService,
    colegioIdDestino, colegios) {
    $scope.exportar = {
        colegioIdDestino,
        colegioIdOrigen:0,
    };
    $scope.colegios = colegios;

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        colegioDataService.exportar($scope.exportar).then(function () {
            $modalInstance.close();
        })
    };
});