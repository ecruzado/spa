app.factory('columnaDataService', function ($http, $log, toaster) {

    var serviceBase = '/api/columna/';
    var columnaDataFactory = {};

    var _columnas = function (colegioId, columnaId,areaId, padreId) {
        return $http.get(serviceBase, {
            params: {
                colegioId: colegioId,
                columnaId: columnaId,
                areaId: areaId,
                padreId: padreId
            }
        }).then(function (results) {
            return results;
        });
    };

    var _saveColumna = function (columna) {
        return $http.post('/api/columna/', columna).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Registro agregado satisfactoriamente!");
            },
            function (results) {
                toaster.pop('error', "Error", "No se pudo guardar el registro!");
                return results;
            }
        );
    };
    columnaDataFactory.columnas = _columnas;
    columnaDataFactory.saveColumna = _saveColumna;

    return columnaDataFactory;
});