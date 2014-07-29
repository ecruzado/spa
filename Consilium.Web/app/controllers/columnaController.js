app.controller('columnaController', function ($scope, $location, $log, $routeParams,
    usuarioSesion, claseDataService, columnaDataService, columnaColegioDataService, toaster) {
    $scope.titulo = $routeParams.nombre;
    $scope.nombre = '';
    $scope.columnaId = $routeParams.columnaId;
    $scope.colegioId = usuarioSesion.getUsuario().colegioId;
    $scope.areas = [];
    $scope.nodo1 = [];
    $scope.nodo2 = [];
    $scope.nodo3 = [];
    $scope.niveles = [];
    $scope.grados = [];
    $scope.nodo1Botones = true;
    $scope.nodo1Form = false;
    $scope.nodo2Botones = false;
    $scope.nodo2Form = false;
    $scope.nodo3Botones = false;
    $scope.nodo3Form = false;
    $scope.actualId = 0;
    $scope.actualPadreId = 0;
    init();

    function init() {
        obtenerAreas();
        obtenerColumnaColegio();
    }

    function obtenerAreas() {
        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
        });

    }

    function obtenerColumnaColegio() {
        columnaColegioDataService.get($scope.columnaId, $scope.colegioId).then(function (resultado) {
            $scope.nombre = resultado.data.nombre;
        });

    }


    $scope.saveColumnaColegio = function () {
        var item = { colegioId: $scope.colegioId, columnaId: $scope.columnaId, nombre: $scope.nombre }
        columnaColegioDataService.saveColumnaColegio(item);
    }

    $scope.obtenerNodo1 = function () {
        $scope.nodo1 = [];
        $scope.nodo2 = [];
        $scope.nodo3 = [];
        $scope.nodo2Botones = false;
        $scope.nodo2Form = false;
        $scope.nodo3Botones = false;
        $scope.nodo3Form = false;
        columnaDataService.columnas($scope.colegioId, $scope.columnaId, $scope.selectedArea, 0).then(function (resultado) {
            $scope.nodo1 = resultado.data;
        });
    }

    $scope.agregarNodo1 = function () {
        $scope.nodo1Botones = false;
        $scope.nodo1Form = true;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.guardarNodo1 = function () {
        $scope.nodo1Botones = true;
        $scope.nodo1Form = false;
        var item = {
            colegioId: $scope.colegioId, columnaId: $scope.columnaId,
            areaId: $scope.selectedArea,
            valor:$scope.actual,
            confColumnaColegioId: $scope.actualId
        };
        columnaDataService.saveColumna(item).then(function () {
            $scope.obtenerNodo1();
        });
    }

    $scope.cancelarNodo1 = function () {
        $scope.nodo1Botones = true;
        $scope.nodo1Form = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarNodo1 = function (id, valor) {
        $scope.nodo1Botones = false;
        $scope.nodo1Form = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

    $scope.seleccionarNodo1 = function (id) {
        $scope.nodo2Botones = true;
        $scope.nodo2Form = false;
        $scope.obtenerNodo2(id);
        $scope.actualPadreId = id;
    }

    $scope.obtenerNodo2 = function (idPadre) {
        $scope.nodo3 = [];
        $scope.nodo2Botones = true;
        $scope.nodo2Form = false;
        $scope.nodo3Botones = false;
        $scope.nodo3Form = false;
        columnaDataService.columnas($scope.colegioId, $scope.columnaId, $scope.selectedArea, idPadre).then(function (resultado) {
            $scope.nodo2 = resultado.data;
        });
    }

    $scope.agregarNodo2 = function () {
        $scope.nodo2Botones = false;
        $scope.nodo2Form = true;
        $scope.actualId = 0;
        $scope.actual = '';
    }

    $scope.guardarNodo2 = function () {
        $scope.nodo2Botones = true;
        $scope.nodo2Form = false;
        var item = {
            colegioId: $scope.colegioId, columnaId: $scope.columnaId,
            areaId: $scope.selectedArea,
            valor: $scope.actual,
            confColumnaColegioId: $scope.actualId,
            ConfColumnaColegioPadreId: $scope.actualPadreId
        };
        columnaDataService.saveColumna(item).then(function () {
            $scope.obtenerNodo2($scope.actualPadreId);
        });
    }

    $scope.cancelarNodo2 = function () {
        $scope.nodo2Botones = true;
        $scope.nodo2Form = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarNodo2 = function (id, valor) {
        $scope.nodo2Botones = false;
        $scope.nodo2Form = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

    $scope.seleccionarNodo2 = function (id) {
        $scope.nodo3Botones = true;
        $scope.nodo3Form = false;
        $scope.obtenerNodo3(id);
        $scope.actualPadreId = id;
    }

    $scope.obtenerNodo3 = function (idPadre) {
        columnaDataService.columnas($scope.colegioId, $scope.columnaId, $scope.selectedArea, idPadre).then(function (resultado) {
            $scope.nodo3 = resultado.data;
        });
    }

    $scope.agregarNodo3 = function () {
        $scope.nodo3Botones = false;
        $scope.nodo3Form = true;
        $scope.actualId = 0;
        $scope.actual = '';
    }

    $scope.guardarNodo3 = function () {
        $scope.nodo3Botones = true;
        $scope.nodo3Form = false;
        var item = {
            colegioId: $scope.colegioId, columnaId: $scope.columnaId,
            areaId: $scope.selectedArea,
            valor: $scope.actual,
            confColumnaColegioId: $scope.actualId,
            ConfColumnaColegioPadreId: $scope.actualPadreId
        };
        columnaDataService.saveColumna(item).then(function () {
            $scope.obtenerNodo3($scope.actualPadreId);
        });
    }

    $scope.cancelarNodo3 = function () {
        $scope.nodo3Botones = true;
        $scope.nodo3Form = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarNodo3 = function (id, valor) {
        $scope.nodo3Botones = false;
        $scope.nodo3Form = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }

});