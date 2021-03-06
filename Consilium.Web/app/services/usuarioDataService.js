﻿app.factory('usuarioDataService', function ($http, $log, toaster) {

    var serviceBase = '/api/usuario/';
    var serviceCambiosBase = '/api/cambiopassword/';
    var usuarioDataFactory = {};

    var _usuarios = function (colegioId) {
        return $http.get(serviceBase, { params: {tipo:'t', colegioId: colegioId } }).then(function (results) {
            return results;
        });
    };

    var _usuario = function (usuarioid) {
        return $http.get(serviceBase, { params: { usuarioId: usuarioid } }).then(function (results) {
            return results;
        }, function (e) {
        });
    };
    var _saveUsuario = function (usuario) {
        return $http.post(serviceBase, usuario).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Registro guardado satisfactoriamente!");
            },
            function (results) {
                toaster.pop('error', "Error", "No se pudo guardar el registro!");
                return results;
            }
        );
    };
    var _cambioPassword = function (usuario) {
        return $http.post(serviceCambiosBase, usuario).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Registro guardado satisfactoriamente!");
            },
            function (results) {
                toaster.pop('error', "Error", "No se pudo guardar el registro!");
                return results;
            }
        );
    };
    usuarioDataFactory.usuarios = _usuarios;
    usuarioDataFactory.usuario = _usuario;
    usuarioDataFactory.saveUsuario = _saveUsuario;
    usuarioDataFactory.cambioPassword = _cambioPassword;
    
    return usuarioDataFactory;
});