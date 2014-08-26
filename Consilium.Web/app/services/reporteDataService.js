app.factory('reporteDataService', function ($http, $log) {

    var serviceBase = '/api/reporte/';
    var reporteDataFactory = {};

    var _obtener = function (tipo,colegioId, areaId, nivelId, gradoId) {
        return $http.get(serviceBase, {
            params: {
                tipo: tipo,
                colegioId: colegioId,
                areaId: areaId,
                nivelId: nivelId,
                gradoId: gradoId
            }
        }).then(function (results) {
            return results;
        });
    };
    reporteDataFactory.obtener = _obtener;

    return reporteDataFactory;
});