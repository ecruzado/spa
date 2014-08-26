app.factory('capacidadDataService', function ($http, $log,toaster) {

    var serviceBase = '/api/capacidad/';
    var deAreaServiceBase = '/api/dearea/';
    var especificaServiceBase = '/api/especifica/';
    var operativaServiceBase = '/api/operativa/';
    var capacidadDataFactory = {};

    var _capacidades = function (colegioId,areaId) {
        return $http.get(serviceBase, { params: { colegioId: colegioId, areaId: areaId } }).then(function (results) {
            return results;
        });
    };

    var _deAreas = function (colegioId,areaId) {
        return $http.get(deAreaServiceBase, { params: { colegioId: colegioId,areaId: areaId } }).then(function (results) {
            return results;
        });
    };
    var _saveDeArea = function (deArea) {
        return $http.post(deAreaServiceBase, deArea).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "De Area guardado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteDeArea = function (deAreaId) {
        return $http.delete(deAreaServiceBase + deAreaId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "De Area eliminado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    var _especificas = function (deAreaId) {
        return $http.get(especificaServiceBase, { params: { deAreaId: deAreaId } }).then(function (results) {
            return results;
        });
    };
    var _saveEspecifica = function (especifica) {
        return $http.post(especificaServiceBase, especifica).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Especifica guardado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteEspecifica = function (especificaId) {
        return $http.delete(especificaServiceBase + especificaId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Especifica eliminada satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    var _operativas = function (especificaId) {
        return $http.get(operativaServiceBase, { params: { especificaId: especificaId } }).then(function (results) {
            return results;
        });
    };
    var _saveOperativa = function (operativa) {
        return $http.post(operativaServiceBase, operativa).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Operativa guardado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteOperativa = function (operativaId) {
        return $http.delete(operativaServiceBase + operativaId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Operativa eliminada satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    capacidadDataFactory.capacidades = _capacidades;

    capacidadDataFactory.deAreas = _deAreas;
    capacidadDataFactory.saveDeArea = _saveDeArea;
    capacidadDataFactory.deleteDeArea = _deleteDeArea;

    capacidadDataFactory.especificas = _especificas;
    capacidadDataFactory.saveEspecifica = _saveEspecifica;
    capacidadDataFactory.deleteEspecifica = _deleteEspecifica;

    capacidadDataFactory.operativas = _operativas;
    capacidadDataFactory.saveOperativa = _saveOperativa;
    capacidadDataFactory.deleteOperativa = _deleteOperativa;

    return capacidadDataFactory;
});