app.factory('contenidoDataService', function ($http, $log,toaster) {

    var serviceBase = '/api/contenido/';
    var conocimientoServiceBase = '/api/conocimiento/';
    var detalleServiceBase = '/api/detalle/';
    var contenidoServiceBase = '/api/contenidomant/';
    var contenidoDataFactory = {};

    var _contenidos = function (colegioId,areaId,nivelId,gradoId) {
        return $http.get(serviceBase, {
            params: {
                colegioId: colegioId,
                areaId: areaId,
                nivelId: nivelId,
                gradoId: gradoId
            }
        }).then(function (results) {
            return results;
        });
    };

    var _conocimientos = function (colegioId, areaId) {
        return $http.get(conocimientoServiceBase, { params: { colegioId: colegioId, areaId: areaId } }).then(function (results) {
            return results;
        });
    };
    var _saveConocimiento = function (conocimiento) {
        return $http.post(conocimientoServiceBase, conocimiento).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Conocimiento guardado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteConocimiento = function (conocimientoId) {
        return $http.delete(conocimientoServiceBase + conocimientoId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Conocimiento eliminado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    var _detalles = function (nivelId, gradoId, conocimientoId) {
        return $http.get(detalleServiceBase, { params: { nivelId: nivelId, gradoId: gradoId, conocimientoId: conocimientoId } }).then(function (results) {
            return results;
        });
    };
    var _saveDetalle = function (detalle) {
        return $http.post(detalleServiceBase, detalle).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Detalle guardado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteDetalle = function (detalleId) {
        return $http.delete(detalleServiceBase + detalleId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Detalle eliminado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    var _contenidosMant = function (detalleId) {
        return $http.get(contenidoServiceBase, { params: { detalleId: detalleId } }).then(function (results) {
            return results;
        });
    };
    var _saveContenido = function (contenido) {
        return $http.post(contenidoServiceBase, contenido).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Contenido guardado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteContenido = function (contenidoId) {
        return $http.delete(contenidoServiceBase + contenidoId).then(
            function (results) {
                toaster.pop('success', "Eliminado Satisfactoriamente", "Contenido eliminado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    contenidoDataFactory.contenidos = _contenidos;

    contenidoDataFactory.conocimientos = _conocimientos;
    contenidoDataFactory.saveConocimiento = _saveConocimiento;
    contenidoDataFactory.deleteConocimiento = _deleteConocimiento;

    contenidoDataFactory.detalles = _detalles;
    contenidoDataFactory.saveDetalle = _saveDetalle;
    contenidoDataFactory.deleteDetalle = _deleteDetalle;

    contenidoDataFactory.contenidosMant = _contenidosMant;
    contenidoDataFactory.saveContenido = _saveContenido;
    contenidoDataFactory.deleteContenido = _deleteContenido;


    return contenidoDataFactory;
});