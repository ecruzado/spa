app.controller('copiarClasePopUpController', function ($scope, $modalInstance, $filter) {
    $scope.claseCopiar = {
        fechaInicioFormato: new Date(),
        fechaFinFormato: new Date(),
    }

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        $scope.claseCopiar.fechaInicioFormato = $filter('date')($scope.claseCopiar.fechaInicioFormato, 'dd/MM/yyyy'),
        $scope.claseCopiar.fechaFinFormato = $filter('date')($scope.claseCopiar.fechaFinFormato, 'dd/MM/yyyy'),

        $modalInstance.close($scope.claseCopiar);
    };

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
});