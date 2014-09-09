app.controller('usuarioController', function ($scope, $location,$modal, usuarioDataService,colegioDataService) {
    $scope.colegios = [];
    $scope.usuarios = [];
    $scope.selectedColegio;

    init();
    function init()
    {
        colegioDataService.colegios().then(function (resultado) {
            $scope.colegios = resultado.data;
        });
    }
    $scope.obtenerUsuarios = function () {
        usuarioDataService.usuarios($scope.selectedColegio).then(function (resultado) {
            $scope.usuarios = resultado.data;
        });
    }

    $scope.popUpUsuario = function (seleccion) {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/usuarioPopUpView.html?v=0.1',
            controller: 'usuarioPopUpController',
            resolve: {
                usuarioSeleccion: function () {
                    return seleccion;
                }
            }
        });
        modalInstance.result.then(function () {
            $scope.obtenerUsuarios();
        });
    };

    $scope.cambioPassword = function (seleccion) {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/cambioPasswordView.html?v=0.1',
            controller: 'cambioPasswordController',
            resolve: {
                usuarioSeleccion: function () {
                    return seleccion;
                }
            }
        });
        modalInstance.result.then(function () {
            $scope.obtenerUsuarios();
        });
    };
});