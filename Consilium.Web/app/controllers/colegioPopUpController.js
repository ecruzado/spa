app.controller('colegioPopUpController', function ($scope, $modalInstance, colegioDataService, colegioSeleccion) {
    $scope.colegio = {
        nombre: '',
        direccion: '',
        telefono: ''
    };

    init();
    function init() {
        if (colegioSeleccion != 0) {
            colegioDataService.colegio(colegioSeleccion).then(function (resultado) {
                $scope.colegio = resultado.data;
            });
        }
    };

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        colegioDataService.saveColegio($scope.colegio).then(function () {
            $modalInstance.close();
        })
    };
});