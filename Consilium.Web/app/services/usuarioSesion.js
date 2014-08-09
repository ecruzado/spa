app.factory('usuarioSesion', function ($http, $log, $location) {

    var usuarioSesion = {};
    var usuario = null;
    init()

    function init() {
        if (usuario == null) {
            obtenerUsuarioServer();
        }
    }

    function obtenerUsuarioServer()
    {
        usuario = {
            usuarioId: 1,
            usuario: 'eicruzado',
            colegioId: 5,
            diseno: true,
            historia: true,
            reporte: true,
            mantenimiento: true,
            administrador: true
        };
    }
    var _getUsuario = function () {
        $log.debug("obtenerUsuarioServer");
        return usuario;
    }
    var _verificarUsuario = function () {
        return $http.get('/account/VerificarUsuario').then(function (results) {
            if (!results.data.sesionActiva)
                window.location= "http://"+window.location.host + "/Account/LogOn";
        });
    }
    usuarioSesion.getUsuario = _getUsuario;
    usuarioSesion.verificarUsuario = _verificarUsuario;

    return usuarioSesion;
});