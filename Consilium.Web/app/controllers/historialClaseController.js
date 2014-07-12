app.controller('historialClaseController', function ($scope, $location, $log, claseDataService) {
    $scope.clases = [];
    init();

    function init() {
        obtenerHistorialClase();
    }

    function obtenerHistorialClase() {
        claseDataService.clases(5).then(function (results) {
            $scope.clases = results.data;

        }, function (error) {
            alert(error.message);
        });
    }
    $scope.editarClase = function(claseId){
        $location.path("/clase/" + claseId);
    }
});