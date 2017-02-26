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

    var _exportarDeArea = function (exportar) {
        return $http.post(deAreaServiceBase+'export/', exportar).then(
            function (results) {
                toaster.pop('success', "Exportado Satisfactoriamente", "De Area exportado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    var _combinarDeArea = function (combinar) {
        return $http.post(deAreaServiceBase + 'combinar/', combinar).then(
            function (results) {
                toaster.pop('success', "Combinado Satisfactoriamente", "De Area combinado satisfactoriamente!");
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
    var _exportarEspecifica = function (exportar) {
        return $http.post(especificaServiceBase + 'export/', exportar).then(
            function (results) {
                toaster.pop('success', "Exportado Satisfactoriamente", "De Area exportado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _combinarEspecifica = function (combinar) {
        return $http.post(especificaServiceBase + 'combinar/', combinar).then(
            function (results) {
                toaster.pop('success', "Combinado Satisfactoriamente", "Especifica combinando satisfactoriamente!");
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
    var _exportarOperativa = function (exportar) {
        return $http.post(operativaServiceBase + 'export/', exportar).then(
            function (results) {
                toaster.pop('success', "Exportado Satisfactoriamente", "De Area exportado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _combinarOperativa = function (combinar) {
        return $http.post(operativaServiceBase + 'combinar/', combinar).then(
            function (results) {
                toaster.pop('success', "Combinado Satisfactoriamente", "Especifica combinando satisfactoriamente!");
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
    capacidadDataFactory.exportarDeArea = _exportarDeArea;
    capacidadDataFactory.combinarDeArea = _combinarDeArea;

    capacidadDataFactory.especificas = _especificas;
    capacidadDataFactory.saveEspecifica = _saveEspecifica;
    capacidadDataFactory.deleteEspecifica = _deleteEspecifica;
    capacidadDataFactory.exportarEspecifica = _exportarEspecifica;
    capacidadDataFactory.combinarEspecifica = _combinarEspecifica;

    capacidadDataFactory.operativas = _operativas;
    capacidadDataFactory.saveOperativa = _saveOperativa;
    capacidadDataFactory.deleteOperativa = _deleteOperativa;
    capacidadDataFactory.exportarOperativa = _exportarOperativa;
    capacidadDataFactory.combinarOperativa = _combinarOperativa;

    return capacidadDataFactory;
});