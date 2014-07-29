app.factory('columnaColegioDataService', function ($http, $log,toaster) {

    var serviceBase = '/api/columnacolegio/';
    var columnaColegioDataFactory = {};

    var _get = function (columnaId, colegioId) {
        return $http.get(serviceBase, { params: { columnaId: columnaId, colegioId: colegioId } }).then(function (results) {
            return results;
        });
    };
    var _saveColumnaColegio = function (columnaColegio) {
        return $http.post('/api/columnacolegio/', columnaColegio).then(
            function (results) {
                toaster.pop('success', "Actualizado Satisfactoriamente", "Entidad actualizada satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };

    columnaColegioDataFactory.get = _get;
    columnaColegioDataFactory.saveColumnaColegio = _saveColumnaColegio;

    return columnaColegioDataFactory;
});