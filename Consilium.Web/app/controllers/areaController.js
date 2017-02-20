app.controller('areaController', function ($scope, $location, $modal, usuarioSesion, claseDataService) {
    $scope.areas = [];
    init();
    function init() {
        claseDataService.areasByColegio(usuarioSesion.getUsuario().colegioId).then(function (resultado) {
            console.log(resultado.data);
            $scope.areas = resultado.data;
        });
    }

    $scope.popUpArea= function (seleccion) {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/areaPopUpView.html',
            controller: 'areaPopUpController',
            resolve: {
                areaSeleccion: function () {
                    return seleccion;
                }
            }
        });
        modalInstance.result.then(function () {
            init();
        });
    };

});