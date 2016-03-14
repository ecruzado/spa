app.controller('valorController', function ($scope, $location, $log, $routeParams,
    usuarioSesion, claseDataService, valorDataService, toaster, arribaAbajoDataService) {
    $scope.colegioId = usuarioSesion.getUsuario().colegioId;
    $scope.areas = [];
    $scope.valores = [];
    $scope.actitudes = [];

    $scope.valorBotones = true;
    $scope.valorForm = false;
    $scope.actitudBotones = false;
    $scope.actitudForm = false;

    $scope.actual = '';
    $scope.actualId = 0;
    $scope.actualPadreId = 0;

    $scope.nodo2NivelArea = false;
    $scope.altoNivel2 = 40;

    init();

    function init() {
        $scope.valores = [];
        $scope.actitudes = [];
        $scope.valorBotones = true;
        $scope.valorForm = false;

        valorDataService.valoresMant($scope.colegioId).then(function (resultado) {
            $scope.valores = resultado.data;
        });
    };

    $scope.obtenerValores = function () {
        $scope.valores = [];
        $scope.actitudes = [];
        $scope.valorBotones = true;
        $scope.valorForm = false;

        valorDataService.valoresMant($scope.colegioId).then(function (resultado) {
            $scope.valores = resultado.data;
        });
    }

    $scope.agregarValor = function () {
        $scope.valorBotones = false;
        $scope.valorForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.guardarValor = function () {
        $scope.valorBotones = true;
        $scope.valorForm = false;
        var item = {
            colegioId: $scope.colegioId,
            valorDsc: $scope.actual,
            valorId: $scope.actualId
        };
        valorDataService.saveValores(item).then(function () {
            $scope.obtenerValores();
        });
    }

    $scope.cancelarValor = function () {
        $scope.valorBotones = true;
        $scope.valorForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarValor = function (id, valor) {
        $scope.valorBotones = false;
        $scope.valorForm = true;
        $scope.actualId = id;
        $scope.actual = valor;
    }

    $scope.seleccionarValor = function (id) {
        $scope.actitudBotones = true;
        $scope.actitudForm = false;
        $scope.obtenerActitudes(id);
        $scope.actualPadreId = id;
    }

    $scope.arribaValor = function (id) {
        var item = {
            entidad: "Valor",
            arriba: true,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerValores();
        });
    }

    $scope.abajoValor = function (id) {
        var item = {
            entidad: "Valor",
            arriba: false,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerValores();
        });
    }

    $scope.obtenerActitudes = function (idPadre) {
        $scope.actitudBotones = true;
        $scope.actitudForm = false;

        valorDataService.actitudes(idPadre).then(function (resultado) {
            $scope.actitudes = resultado.data;
        });
    }

    $scope.agregarActitud = function () {
        $scope.actitudBotones = false;
        $scope.actitudForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
    }

    $scope.guardarActitud = function () {
        $scope.actitudBotones = true;
        $scope.actitudForm = false;
        var item = {
            valorId: $scope.actualPadreId,
            actitud: $scope.actual,
            actitudId: $scope.actualId
        };
        valorDataService.saveActitud(item).then(function () {
            $scope.obtenerActitudes($scope.actualPadreId);
        });
    }

    $scope.cancelarActitud = function () {
        $scope.actitudBotones = true;
        $scope.actitudForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarActitud = function (id, valor) {
        $scope.actitudBotones = false;
        $scope.actitudForm = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

    $scope.arribaActitud = function (id) {
        var item = {
            entidad: "Actitud",
            arriba: true,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerActitudes($scope.actualPadreId);
        });
    }

    $scope.abajoActitud = function (id) {
        var item = {
            entidad: "Actitud",
            arriba: false,
            id1: id
        };
        arribaAbajoDataService.saveArribaAbajo(item).then(function () {
            $scope.obtenerActitudes($scope.actualPadreId);
        });
    }
});