app.controller('columnaController', function ($scope, $location, $log, $routeParams, claseDataService,columnaDataService, toaster) {
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
    }

    function obtenerAreas() {
        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
        });

    }

    $scope.obtenerNodo1 = function () {
        columnaDataService.columnas(5,1,$scope.selectedArea,0).then(function (resultado) {
            $scope.nodo1 = resultado.data;
        });
    }
    $scope.obtenerNodo2 = function (idPadre) {
        columnaDataService.columnas(5, 1, $scope.selectedArea, idPadre).then(function (resultado) {
            $scope.nodo2 = resultado.data;
        });
    }
    $scope.obtenerNodo3 = function (idPadre) {
        columnaDataService.columnas(5, 1, $scope.selectedArea, idPadre).then(function (resultado) {
            $scope.nodo3 = resultado.data;
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
        var item = { colegioId: 5, columnaId: 1, 
            areaId: $scope.selectedArea,
            valor:$scope.actual,
            confColumnaColegioId: $scope.actualId
        };
        columnaDataService.saveColumna(item).then(function () {
            $scope.obtenerNodo1();
        });
    }
    $scope.editarNodo1 = function (id,valor) {
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
            colegioId: 5, columnaId: 1,
            areaId: $scope.selectedArea,
            valor: $scope.actual,
            confColumnaColegioId: $scope.actualId,
            ConfColumnaColegioPadreId: $scope.actualPadreId
        };
        columnaDataService.saveColumna(item).then(function () {
            $scope.obtenerNodo2($scope.actualPadreId);
        });
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
            colegioId: 5, columnaId: 1,
            areaId: $scope.selectedArea,
            valor: $scope.actual,
            confColumnaColegioId: $scope.actualId,
            ConfColumnaColegioPadreId: $scope.actualPadreId
        };
        columnaDataService.saveColumna(item).then(function () {
            $scope.obtenerNodo3($scope.actualPadreId);
        });
    }
    $scope.editarNodo3 = function (id, valor) {
        $scope.nodo3Botones = false;
        $scope.nodo3Form = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }


});