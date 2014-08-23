app.factory('valorDataService', function ($http, $log) {

    var serviceBase = '/api/valor/';
    var valorDataFactory = {};

    var _valores = function (colegioId) {
        return $http.get(serviceBase, { params: { colegioId: colegioId} }).then(function (results) {
            return results;
        });
    };
    valorDataFactory.valores = _valores;

    return valorDataFactory;
});