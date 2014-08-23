app.factory('metodologiaDataService', function ($http, $log) {

    var serviceBase = '/api/metodologia/';
    var metodologiaDataFactory = {};

    var _metodologias = function (colegioId) {
        return $http.get(serviceBase, { params: { colegioId: colegioId } }).then(function (results) {
            return results;
        });
    };
    metodologiaDataFactory.metodologias = _metodologias;

    return metodologiaDataFactory;
});