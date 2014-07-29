app.factory('usuarioSesion', function ($http, $log) {

    var serviceBase = '/api/capacidad/';
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
        return usuario;
    }

    usuarioSesion.getUsuario = _getUsuario;

    return usuarioSesion;
});