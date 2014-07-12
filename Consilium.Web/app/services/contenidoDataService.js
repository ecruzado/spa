app.factory('contenidoDataService', function ($http, $log) {

    var serviceBase = '/api/contenido/';
    var contenidoDataFactory = {};

    var _contenidos = function (colegioId,areaId,nivelId,gradoId) {
        return $http.get(serviceBase, {
            params: {
                colegioId: colegioId,
                areaId: areaId,
                nivelId: nivelId,
                gradoId: gradoId
            }
        }).then(function (results) {
            return results;
        });
    };
    contenidoDataFactory.contenidos = _contenidos;

    return contenidoDataFactory;
});