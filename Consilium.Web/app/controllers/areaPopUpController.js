app.controller('areaPopUpController', function ($scope, $modalInstance, claseDataService, areaSeleccion) {
    $scope.area = {
        nombre: '',
    };

    init();
    function init() {
        if (areaSeleccion) {
                $scope.area = areaSeleccion;
        }
    };

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        claseDataService.saveArea($scope.area).then(function () {
            $modalInstance.close();
        })
    };
});