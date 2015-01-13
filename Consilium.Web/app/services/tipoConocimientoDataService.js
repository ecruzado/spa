app.factory('tipoConocimientoDataService', function ($http, $log) {

    var serviceBase = '/api/tipoconocimiento/';
    var tipoConocimientoDataFactory = {};

    var _tipoConocimientos = function () {
        return $http.get(serviceBase, { params: {} }).then(function (results) {
            return results;
        });
    };
    tipoConocimientoDataFactory.tipoConocimientos = _tipoConocimientos;

    return tipoConocimientoDataFactory;
});