app.controller('contenidoController', function ($scope, $location, $log,
    usuarioSesion, claseDataService, contenidoDataService, toaster, arribaAbajoDataService) {
    $scope.colegioId = usuarioSesion.getUsuario().colegioId;
    $scope.areas = [];
    $scope.conocimientos = [];
    $scope.detalles = [];
    $scope.contenidos = [];
    $scope.niveles = [];
    $scope.grados = [];
    $scope.conocimientoBotones = true;
    $scope.conocimientoForm = false;
    $scope.detalleBotones = false;
    $scope.detalleForm = false;
    $scope.contenidoBotones = false;
    $scope.contenidoForm = false;
    $scope.actualId = 0;
    $scope.actualPadreId = 0;
    $scope.actualPadreNodo3Id = 0;

    $scope.nodo2NivelArea = false;
    $scope.altoNivel2 = 40;
    $scope.niveles = [];
    $scope.grados = [{ gradoId: 0, gradoDesc: '--Seleccionar Grado--' }];
    $scope.nivelId = 0;
    $scope.gradoId = 0;

    init();

    function init() {
        obtenerAreas();
        obtenerNiveles();
        $scope.nodo2NivelArea = true;
        $scope.altoNivel2 = 65;
    }

    function obtenerAreas() {
        claseDataService.areas(usuarioSesion.getUsuario().colegioId).then(function (resultado) {
            $scope.areas = resultado.data;
        });

    }
    function obtenerNiveles() {
        claseDataService.niveles().then(function (resultado) {
            $scope.niveles = resultado.data;
        });
    }

    $scope.obtenerConocimientos = function () {
        $scope.conocimientos = [];
        $scope.detalles = [];
        $scope.contenidos = [];
        $scope.detalleBotones = false;
        $scope.detalleForm = false;
        $scope.contenidoBotones = false;
        $scope.contenidoForm = false;
        contenidoDataService.conocimientos($scope.colegioId, $scope.selectedArea)
            .then(function (resultado) {
                $scope.conocimientos = resultado.data;
            });
    }

    $scope.agregarConocimiento = function () {
        $scope.conocimientoBotones = false;
        $scope.conocimientoForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.guardarConocimiento = function () {
        $scope.conocimientoBotones = true;
        $scope.conocimientoForm = false;
        var item = {
            colegioId: $scope.colegioId, columnaId: $scope.columnaId,
            area: $scope.selectedArea,
            conocimiento: $scope.actual,
            conocimientoId: $scope.actualId
        };
        contenidoDataService.saveConocimiento(item).then(function () {
            $scope.obtenerConocimientos();
        });
    }

    $scope.cancelarConocimiento = function () {
        $scope.conocimientoBotones = true;
        $scope.conocimientoForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarConocimiento = function (id, valor) {
        $scope.conocimientoBotones = false;
        $scope.conocimientoForm = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

    $scope.seleccionarConocimiento = function (id) {
        $scope.detalleBotones = true;
        $scope.detalleForm = false;
        $scope.obtenerDetalles(id);
        $scope.actualPadreId = id;
    }

    $scope.arribaConocimiento = function (id) {
        var item = {
            entidad: "Conocimiento",
            arriba: true,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerConocimientos();
        });
    }

    $scope.abajoConocimiento = function (id) {
        var item = {
            entidad: "Conocimiento",
            arriba: false,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerConocimientos();
        });
    }

    $scope.obtenerDetalles = function (idPadre) {
        $scope.contenidos = [];
        $scope.detalleBotones = true;
        $scope.detalleForm = false;
        $scope.contenidoBotones = false;
        $scope.contenidoForm = false;
        var auxNivelId = $scope.nivelId;
        var auxGradoId = $scope.gradoId;

        contenidoDataService.detalles(auxNivelId, auxGradoId, idPadre).then(function (resultado) {
            $scope.detalles = resultado.data;
        });
    }

    $scope.agregarDetalle = function () {
        $scope.detalleBotones = false;
        $scope.detalleForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
    }

    $scope.guardarDetalle = function () {
        $scope.detalleBotones = true;
        $scope.detalleForm = false;
        var item = {
            nivelId: $scope.nivelId,
            gradoId: $scope.gradoId,
            conocimientoId: $scope.actualPadreId,
            detalle: $scope.actual,
            detalleId: $scope.actualId,
        };
        contenidoDataService.saveDetalle(item).then(function () {
            $scope.obtenerDetalles($scope.actualPadreId);
        });
    }

    $scope.cancelarDetalle = function () {
        $scope.detalleBotones = true;
        $scope.detalleForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarDetalle = function (id, valor) {
        $scope.detalleBotones = false;
        $scope.detalleForm = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

    $scope.seleccionarDetalle = function (id) {
        $scope.contenidoBotones = true;
        $scope.contenidoForm = false;
        $scope.obtenerContenidos(id);
        $scope.actualPadreNodo3Id = id;
    }

    $scope.arribaDetalle = function (id) {
        var item = {
            entidad: "Detalle",
            arriba: true,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerDetalles($scope.actualPadreId);
        });
    }

    $scope.abajoDetalle = function (id) {
        var item = {
            entidad: "Detalle",
            arriba: false,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerDetalles($scope.actualPadreId);
        });
    }

    $scope.obtenerContenidos = function (idPadre) {
        contenidoDataService.contenidosMant(idPadre).then(function (resultado) {
                $scope.contenidos = resultado.data;
            });
    }

    $scope.agregarContenido = function () {
        $scope.contenidoBotones = false;
        $scope.contenidoForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
    }

    $scope.guardarContenido = function () {
        $scope.contenidoBotones = true;
        $scope.contenidoForm = false;
        var item = {
            contenidoDesc: $scope.actual,
            contenidoId: $scope.actualId,
            detalleId: $scope.actualPadreNodo3Id
        };
        contenidoDataService.saveContenido(item).then(function () {
            $scope.obtenerContenidos($scope.actualPadreNodo3Id);
        });
    }

    $scope.cancelarContenido = function () {
        $scope.contenidoBotones = true;
        $scope.contenidoForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarContenido = function (id, valor) {
        $scope.contenidoBotones = false;
        $scope.contenidoForm = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

    $scope.obtenerGrados = function () {
        claseDataService.grados($scope.nivelId).then(function (resultado) {
            $scope.gradoId = 0;
            $scope.grados = resultado.data;
            $scope.detalles = [];
        });
    }

    $scope.arribaContenido = function (id) {
        var item = {
            entidad: "Contenido",
            arriba: true,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerContenidos($scope.actualPadreNodo3Id);
        });
    }

    $scope.abajoContenido = function (id) {
        var item = {
            entidad: "Contenido",
            arriba: false,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerContenidos($scope.actualPadreNodo3Id);
        });
    }

});