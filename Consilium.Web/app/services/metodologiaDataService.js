app.factory('metodologiaDataService', function ($http, $log,toaster) {

    var serviceBase = '/api/metodologia/';
    var criterioServiceBase = '/api/criterio/';
    var metecnicaServiceBase = '/api/metecnica/';
    var metodologiaDataFactory = {};

    var _metodologias = function (colegioId) {
        return $http.get(serviceBase, { params: { colegioId: colegioId } }).then(function (results) {
            return results;
        });
    };

    var _criterios = function (colegioId, areaId) {
        return $http.get(criterioServiceBase, { params: { colegioId: colegioId,areaId: areaId } }).then(function (results) {
            return results;
        });
    };
    var _saveCriterio = function (criterio) {
        return $http.post(criterioServiceBase, criterio).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Criterio agregado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteCriterio = function (criterioId) {
        return $http.delete(criterioServiceBase + criterioId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Criterio eliminado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    var _metecnicas = function (criterioId) {
        return $http.get(metecnicaServiceBase, { params: { criterioId: criterioId} }).then(function (results) {
            return results;
        });
    };
    var _saveMetecnica = function (metecnica) {
        return $http.post(metecnicaServiceBase, metecnica).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Metecnica agregado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteMetecnica = function (metecnicaId) {
        return $http.delete(metecnicaServiceBase + metecnicaId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Metecnica eliminada satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };


    metodologiaDataFactory.metodologias = _metodologias;
    metodologiaDataFactory.criterios = _criterios;
    metodologiaDataFactory.saveCriterio = _saveCriterio;
    metodologiaDataFactory.deleteCriterio = _deleteCriterio;
    metodologiaDataFactory.metecnicas = _metecnicas;
    metodologiaDataFactory.saveMetecnica = _saveMetecnica;
    metodologiaDataFactory.deleteMetecnica = _deleteMetecnica;

    return metodologiaDataFactory;
});