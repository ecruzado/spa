app.factory('valorDataService', function ($http, $log,toaster) {

    var serviceBase = '/api/valor/';
    var valoresServiceBase = '/api/valores/';
    var actitudServiceBase = '/api/actitud/';
    var valorDataFactory = {};

    var _valores = function (colegioId) {
        return $http.get(serviceBase, { params: { colegioId: colegioId} }).then(function (results) {
            return results;
        });
    };

    var _valoresMant = function (colegioId) {
        return $http.get(valoresServiceBase, { params: { colegioId: colegioId } }).then(function (results) {
            return results;
        });
    };
    var _saveValores = function (valor) {
        return $http.post(valoresServiceBase, valor).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Valor agregado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteValores = function (valorId) {
        return $http.delete(valoresServiceBase + valorId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Valor eliminado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };

    var _actitudes = function (valorId) {
        return $http.get(actitudServiceBase, { params: { valorId: valorId } }).then(function (results) {
            return results;
        });
    };
    var _saveActitud = function (actitud) {
        return $http.post(actitudServiceBase, actitud).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Actitud guardado satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteActitud = function (actitudId) {
        return $http.delete(actitudServiceBase + actitudId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Actitud eliminada satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };


    valorDataFactory.valores = _valores;
    valorDataFactory.valoresMant = _valoresMant;
    valorDataFactory.saveValores = _saveValores;
    valorDataFactory.deleteValores = _deleteValores;
    valorDataFactory.actitudes = _actitudes;
    valorDataFactory.saveActitud = _saveActitud;
    valorDataFactory.deleteActitud = _deleteActitud;


    return valorDataFactory;
});