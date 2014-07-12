app.factory('capacidadDataService', function ($http, $log) {

    var serviceBase = '/api/capacidad/';
    var capacidadDataFactory = {};

    var _capacidades = function (colegioId,areaId) {
        return $http.get(serviceBase, { params: { colegioId: colegioId, areaId: areaId } }).then(function (results) {
            return results;
        });
    };
    capacidadDataFactory.capacidades = _capacidades;

    return capacidadDataFactory;
});