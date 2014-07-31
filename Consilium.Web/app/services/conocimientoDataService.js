app.factory('conocimientoDataService', function ($http, $log) {

    var serviceBase = '/api/conocimiento/';
    var conocimientoDataFactory = {};

    var _conocimientos = function () {
        return $http.get(serviceBase, { params: {} }).then(function (results) {
            return results;
        });
    };
    conocimientoDataFactory.conocimientos = _conocimientos;

    return conocimientoDataFactory;
}); 