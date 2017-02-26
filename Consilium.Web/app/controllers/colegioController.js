app.controller('colegioController', function ($scope, $location, $modal,colegioDataService) {
    $scope.colegios = [];

    init();
    function init() {
        colegioDataService.colegios().then(function (resultado) {
            $scope.colegios = resultado.data;
        });
    }

    $scope.popUpColegio= function (seleccion) {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/colegioPopUpView.html',
            controller: 'colegioPopUpController',
            resolve: {
                colegioSeleccion: function () {
                    return seleccion;
                }
            }
        });
        modalInstance.result.then(function () {
            init();
        });
    };

    $scope.popUpExportar = function (seleccion) {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/exportarColegioPopUpView.html',
            controller: 'exportarColegioPopUpController',
            resolve: {
                colegioIdDestino: function () {
                    return seleccion;
                },
                colegios: function () {
                    return $scope.colegios;
                }
            }
        });
        modalInstance.result.then(function () {
            init();
        });
    };

});