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
        obtenerColumnaColegio();
        if ($scope.columnaId == 3 || $scope.columnaId == 4) {
            $scope.nodo2NivelArea = true;
            $scope.altoNivel2 = 65;
            obtenerNiveles();
        }
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
        columnaDataService.columnas($scope.colegioId, $scope.columnaId, $scope.selectedArea, 0,
            0, 0)
            .then(function (resultado) {
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
        var auxNivelId = $scope.nivelId;
        var auxGradoId = $scope.gradoId;
        if ($scope.columnaId == 3 || $scope.columnaId == 4) {
            if (auxNivelId == 0)
                auxNivelId = -1;
            if (auxGradoId == 0)
                auxGradoId = -1;
        }
        columnaDataService.columnas($scope.colegioId, $scope.columnaId, $scope.selectedArea, idPadre,
            auxNivelId, auxGradoId)
            .then(function (resultado) {
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
            colegioId: $scope.colegioId,
            columnaId: $scope.columnaId,
            areaId: $scope.selectedArea,
            valor: $scope.actual,
            confColumnaColegioId: $scope.actualId,
            ConfColumnaColegioPadreId: $scope.actualPadreId,
            nivelId: $scope.nivelId,
            gradoId: $scope.gradoId
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
        $scope.actualPadreNodo3Id = id;
    }

    $scope.obtenerNodo3 = function (idPadre) {
        columnaDataService.columnas($scope.colegioId, $scope.columnaId, $scope.selectedArea, idPadre,
            0, 0)
            .then(function (resultado) {
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
            ConfColumnaColegioPadreId: $scope.actualPadreNodo3Id
        };
        columnaDataService.saveColumna(item).then(function () {
            $scope.obtenerNodo3($scope.actualPadreNodo3Id);
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

    $scope.obtenerGrados = function () {
        claseDataService.grados($scope.nivelId).then(function (resultado) {
            $scope.gradoId = 0;
            $scope.grados = resultado.data;
            $scope.nodo2 = [];
        });
    }


});