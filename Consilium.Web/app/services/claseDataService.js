app.factory('claseDataService', function ($http, $log, toaster) {

    var claseDataFactory = {};

    var _niveles = function () {
        return $http.get('/api/nivel/', { params: {} }).then(function (results) {
            return results;
        });
    };

    var _grados = function (nivelId) {
        return $http.get('/api/grado/', { params: { nivelId: nivelId } }).then(function (results) {
            return results;
        });
    };

    var _claseCapacidades = function (claseId) {
        return $http.get('/api/clasecapacidad/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseCapacidad = function (claseCapacidad) {
        return $http.post('/api/clasecapacidad/', claseCapacidad).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Capacidad agregada satisfactoriamente!");
            },
            function (results) {
                alert('sucks');
                return results;
            }
        );
    };
    var _deleteClaseCapacidad = function (claseCapacidadId) {
        return $http.delete('/api/clasecapacidad/' + claseCapacidadId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Capacidad eliminada satisfactoriamente!");
            },
            function (results) {
                alert('sucks');
                return results;
            }
        );
    };
    var _clases = function (colegioId) {
        return $http.get('/api/clase/', { params: { colegioId: colegioId } }).then(function (results) {
            return results;
        });
    };
    var _clase = function (claseId) {
        return $http.get('/api/clase/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };

    var _claseContenidos = function (claseId) {
        return $http.get('/api/clasecontenido/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _claseValores = function (claseId) {
        return $http.get('/api/clasevalor/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _claseMetodos = function (claseId) {
        return $http.get('/api/clasemetodo/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };

    var _claseActividades = function (claseId) {
        return $http.get('/api/claseactividad/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _claseActividadUpdate = function (claseActividad) {
        return $http.post('/api/claseactividad/', claseActividad).then(function (results) {
            return results;
        });
    };


    claseDataFactory.niveles = _niveles;
    claseDataFactory.grados = _grados;

    claseDataFactory.clases = _clases;
    claseDataFactory.clase = _clase;

    claseDataFactory.claseCapacidades = _claseCapacidades;
    claseDataFactory.saveClaseCapacidad = _saveClaseCapacidad;
    claseDataFactory.deleteClaseCapacidad = _deleteClaseCapacidad;

    claseDataFactory.claseContenidos = _claseContenidos;
    claseDataFactory.claseValores = _claseValores;
    claseDataFactory.claseMetodos = _claseMetodos;

    claseDataFactory.claseActividades = _claseActividades;
    claseDataFactory.claseActividadUpdate = _claseActividadUpdate;

    return claseDataFactory;
});