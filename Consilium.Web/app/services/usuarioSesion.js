app.factory('usuarioSesion', function ($http, $log, $location) {

    var usuarioSesion = {};
    var usuario = null;

    var _obtenerUsuarioServer = function (){
        return $http.get('/account/ObtenerUsuario').then(function (results) {
            usuario = results.data;
            usuario.colegioId = usuario.ColegioId;
            usuario.codigo = usuario.Codigo;
            return usuario;
        }, function (error) {
            $log.debug(error);
        });
    }

    var _getUsuario = function () {
        return usuario;
    }
    var _verificarUsuario = function () {
        return $http.get('/account/VerificarUsuario').then(function (results) {
            if (!results.data.sesionActiva) {
                window.location = "http://consilium-educacion.jimdo.com";
            }
        }, function (error) {
            //window.location = "http://" + window.location.host + "/Account/LogOn";
            window.location = "http://consilium-educacion.jimdo.com";
        });
    }
    usuarioSesion.getUsuario = _getUsuario;
    usuarioSesion.verificarUsuario = _verificarUsuario;
    usuarioSesion.obtenerUsuarioServer = _obtenerUsuarioServer;

    return usuarioSesion;
});