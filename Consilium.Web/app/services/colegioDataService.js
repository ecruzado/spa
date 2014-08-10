app.factory('colegioDataService', function ($http, $log, toaster) {

    var serviceBase = '/api/colegio/';
    var colegioDataFactory = {};

    var _colegios = function () {
        return $http.get(serviceBase, { params: {} }).then(function (results) {
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
    colegioDataFactory.colegios = _colegios;
    colegioDataFactory.saveColegio = _saveColegio;

    return colegioDataFactory;
});