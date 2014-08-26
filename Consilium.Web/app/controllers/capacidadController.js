﻿app.controller('capacidadController', function ($scope, $location, $log, $routeParams,
    usuarioSesion, claseDataService, capacidadDataService, toaster) {
    $scope.nombre = '';
    $scope.colegioId = usuarioSesion.getUsuario().colegioId;
    $scope.areas = [];
    $scope.deAreas = [];
    $scope.especificas = [];
    $scope.operativas = [];
    $scope.deAreaBotones = true;
    $scope.deAreaForm = false;
    $scope.especificaBotones = false;
    $scope.especificaForm = false;
    $scope.operativaBotones = false;
    $scope.operativaForm = false;

    $scope.actualId = 0;
    $scope.actualPadreId = 0;
    $scope.actualPadreNodo3Id = 0;

    init();

    function init() {
        obtenerAreas();
    }

    function obtenerAreas() {
        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
        });

    }

    $scope.obtenerDeArea = function () {
        $scope.deAreas = [];
        $scope.especificas = [];
        $scope.operativas = [];
        $scope.especificaBotones = false;
        $scope.especificaForm = false;
        $scope.operativaBotones = false;
        $scope.operativaForm = false;
        capacidadDataService.deAreas($scope.colegioId, $scope.selectedArea).then(function (resultado) {
            $scope.deAreas = resultado.data;
        });
    }

    $scope.agregarDeArea = function () {
        $scope.deAreaBotones = false;
        $scope.deAreaForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.guardarDeArea = function () {
        $scope.deAreaBotones = true;
        $scope.deAreaForm = false;
        var item = {
            colegioId: $scope.colegioId, columnaId: $scope.columnaId,
            areaId: $scope.selectedArea,
            deArea: $scope.actual,
            deAreaId: $scope.actualId
        };
        capacidadDataService.saveDeArea(item).then(function () {
            $scope.obtenerDeArea();
        });
    }

    $scope.cancelarDeArea = function () {
        $scope.deAreaBotones = true;
        $scope.deAreaForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarDeArea = function (id, valor) {
        $scope.deAreaBotones = false;
        $scope.deAreaForm = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

    $scope.seleccionarDeArea = function (id) {
        $scope.especificaBotones = true;
        $scope.especificaForm = false;
        $scope.obtenerEspecifica(id);
        $scope.actualPadreId = id;
    }

    $scope.obtenerEspecifica = function (idPadre) {
        $scope.operativas = [];
        $scope.especificaBotones = true;
        $scope.especificaForm = false;
        $scope.operativaBotones = false;
        $scope.operativaForm = false;

        capacidadDataService.especificas(idPadre).then(function (resultado) {
            $scope.especificas = resultado.data;
        });
    }

    $scope.agregarEspecifica = function () {
        $scope.especificaBotones = false;
        $scope.especificaForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
    }

    $scope.guardarEspecifica = function () {
        $scope.especificaBotones = true;
        $scope.especificaForm = false;
        var item = {
            especifica: $scope.actual,
            especificaId: $scope.actualId,
            deAreaId:$scope.actualPadreId
        };
        capacidadDataService.saveEspecifica(item).then(function () {
            $scope.obtenerEspecifica($scope.actualPadreId);
        });
    }

    $scope.cancelarEspecifica = function () {
        $scope.especificaBotones = true;
        $scope.especificaForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarEspecifica = function (id, valor) {
        $scope.especificaBotones = false;
        $scope.especificaForm = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

    $scope.seleccionarEspecifica = function (id) {
        $scope.operativaBotones = true;
        $scope.operativaForm = false;
        $scope.obtenerOperativa(id);
        $scope.actualPadreNodo3Id = id;
    }

    $scope.obtenerOperativa = function (idPadre) {
        capacidadDataService.operativas(idPadre).then(function (resultado) {
            $scope.operativas = resultado.data;
        });
    }

    $scope.agregarOperativa = function () {
        $scope.operativaBotones = false;
        $scope.operativaForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
    }

    $scope.guardarOperativa = function () {
        $scope.operativaBotones = true;
        $scope.operativaForm = false;
        var item = {
            operativa: $scope.actual,
            operativaId: $scope.actualId,
            especificaId: $scope.actualPadreNodo3Id
        };
        capacidadDataService.saveOperativa(item).then(function () {
            $scope.obtenerOperativa($scope.actualPadreNodo3Id);
        });
    }

    $scope.cancelarOperativa = function () {
        $scope.operativaBotones = true;
        $scope.operativaForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarOperativa = function (id, valor) {
        $scope.operativaBotones = false;
        $scope.operativaForm = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

});