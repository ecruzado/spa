app.controller('eliminarClasePopUpController', function ($scope, $modalInstance) {
    $scope.confirmarEliminar = false;
    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.eliminar = function () {
        $scope.confirmarEliminar = true;
        $modalInstance.close($scope.confirmarEliminar);
    };

});