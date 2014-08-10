app.controller('sesionController', function ($scope, $location, usuarioSesion) {
    $scope.colegio = '';
    $scope.usuario = false;
    init();

    function init() {
        usuarioSesion.obtenerUsuarioServer().then(function (usuario) {
            $scope.colegio = usuario.Colegio;
            $scope.usuario = usuario.Codigo;
        });
    }


});