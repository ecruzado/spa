app.factory('listaColumnaDataService', function ($http, $log) {

    var serviceBase = '/api/listacolumna/';
    var listaColumnaDataFactory = {};

    var _listaColumnas = function (columnaId,colegioId,areaId) {
        return $http.get(serviceBase, { params: {columnaId:columnaId, colegioId: colegioId, areaId: areaId } }).then(function (results) {
            return results;
        });
    };
    listaColumnaDataFactory.listaColumnas = _listaColumnas;

    return listaColumnaDataFactory;
});