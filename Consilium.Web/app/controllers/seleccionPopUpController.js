app.controller('seleccionPopUpController', function ($scope, $modalInstance, items) {
    $scope.items = items;
    $scope.selectedItem = { item: 0 };

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        $modalInstance.close($scope.selectedItem.item);
    };
});