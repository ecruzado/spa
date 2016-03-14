app.factory('arribaAbajoDataService', function ($http, $log, toaster) {

    var arribaAbajoServiceBase = '/api/arribaAbajo/';
    var valorDataFactory = {};

    var _saveArribaAbajo = function (valor) {
        return $http.post(arribaAbajoServiceBase, valor).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Guardado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    valorDataFactory.saveArribaAbajo = _saveArribaAbajo;


    return valorDataFactory;
});