app.factory('pruebaDataService', function ($http, $log) {

    var serviceBase = '/api/prueba/';
    var pruebaDataFactory = {};

    var _pruebas = function () {
        return $http.get(serviceBase, { params: {} }).then(function (results) {
            return results;
        });
    };
    pruebaDataFactory.pruebas = _pruebas;

    return pruebaDataFactory;
});