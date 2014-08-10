﻿app.controller('navigationController', function ($scope, $location, usuarioSesion) {
    $scope.disenoClase = false;
    $scope.historialClase = false;
    $scope.reporte = false;
    $scope.mantenimiento = false;
    $scope.administrador = false;
    init();

    function init() {
        usuarioSesion.obtenerUsuarioServer().then(function (usuario) {
            $scope.disenoClase = usuario.DisenoClase;
            $scope.historialClase = usuario.HistorialClase;
            $scope.reporte = usuario.Reporte;
            $scope.mantenimiento = usuario.Mantenimiento;
            $scope.administrador = usuario.Administrador;
        });
    }

    $scope.isActive = function (path) {
        return $location.path().substr(0, path.length) == path;
    };

});