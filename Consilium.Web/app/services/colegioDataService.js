﻿app.factory('colegioDataService', function ($http, $log, toaster) {

    var serviceBase = '/api/colegio/';
    var colegioDataFactory = {};

    var _colegios = function () {
        return $http.get(serviceBase, { params: {} }).then(function (results) {
            return results;
        });
    };

    var _colegio = function (colegioId) {
        return $http.get(serviceBase, { params: {colegioId:colegioId} }).then(function (results) {
            return results;
        });
    };
    var _saveColegio = function (colegio) {
        return $http.post(serviceBase, colegio).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Registro guardado satisfactoriamente!");
            },
            function (results) {
                toaster.pop('error', "Error", "No se pudo guardar el registro!");
                return results;
            }
        );
    };

    var _exportar = function (exportar) {
        return $http.post(serviceBase+'exportar/', exportar).then(
            function (results) {
                toaster.pop('success', "Se importo satisfactoriamente los datos", "Se importo satisfactoriamente los datos!");
            },
            function (results) {
                toaster.pop('error', "Error", "No se pudo importar los registros!");
                return results;
            }
        );
    };
    colegioDataFactory.colegios = _colegios;
    colegioDataFactory.colegio = _colegio;
    colegioDataFactory.saveColegio = _saveColegio;
    colegioDataFactory.exportar = _exportar;

    return colegioDataFactory;
});