app.controller('comentarioController', function ($scope, $location, $filter, $log, $modal,
    usuarioSesion, claseDataService, usuarioDataService) {

    init();

    function init() {
        claseDataService.claseComentarios(0, usuarioSesion.getUsuario().codigo).then(function (resultado) {
            $scope.comentarios = resultado.data;
        });

    }

});