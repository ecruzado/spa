app.controller('metodologiaController', function ($scope, $location, $log, $routeParams,
    usuarioSesion,claseDataService, metodologiaDataService, toaster) {
    $scope.colegioId = usuarioSesion.getUsuario().colegioId;
    $scope.areas = [];
    $scope.criterios = [];
    $scope.metecnicas = [];

    $scope.criterioBotones = true;
    $scope.criterioForm = false;
    $scope.metecnicaBotones = false;
    $scope.metecnicaForm = false;

    $scope.actual = '';
    $scope.actualId = 0;
    $scope.actualPadreId = 0;

    $scope.nodo2NivelArea = false;
    $scope.altoNivel2 = 40;

    init();

    function init() {
        obtenerAreas();
    }

    function obtenerAreas() {
        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
        });

    }

    $scope.obtenerCriterios = function () {
        $scope.criterios = [];
        $scope.metecnicas = [];
        $scope.criterioBotones = true;
        $scope.criterioForm = false;

        metodologiaDataService.criterios($scope.colegioId, $scope.selectedArea).then(function (resultado) {
            $scope.criterios = resultado.data;
        });
    }

    $scope.agregarCriterio = function () {
        $scope.criterioBotones = false;
        $scope.criterioForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.guardarCriterio = function () {
        $scope.criterioBotones = true;
        $scope.criterioForm = false;
        var item = {
            colegioId: $scope.colegioId,
            areaId: $scope.selectedArea,
            criterio: $scope.actual,
            criterioId: $scope.actualId
        };
        metodologiaDataService.saveCriterio(item).then(function () {
            $scope.obtenerCriterios();
        });
    }

    $scope.cancelarCriterio = function () {
        $scope.criterioBotones = true;
        $scope.criterioForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarCriterio = function (id, valor) {
        $scope.criterioBotones = false;
        $scope.criterioForm = true;
        $scope.actualId = id;
        $scope.actual = valor;
    }

    $scope.seleccionarCriterio = function (id) {
        $scope.metecnicaBotones = true;
        $scope.metecnicaForm = false;
        $scope.obtenerMetecnicas(id);
        $scope.actualPadreId = id;
    }

    $scope.obtenerMetecnicas = function (idPadre) {
        $scope.metecnicaBotones = true;
        $scope.metecnicaForm = false;

        metodologiaDataService.metecnicas(idPadre).then(function (resultado) {
            $scope.metecnicas = resultado.data;
        });
    }

    $scope.agregarMetecnica = function () {
        $scope.metecnicaBotones = false;
        $scope.metecnicaForm = true;
        $scope.actualId = 0;
        $scope.actual = '';
    }

    $scope.guardarMetecnica = function () {
        $scope.metecnicaBotones = true;
        $scope.metecnicaForm = false;
        var item = {
            criterioId: $scope.actualPadreId,
            metecnica: $scope.actual,
            metecnicaId: $scope.actualId
        };
        metodologiaDataService.saveMetecnica(item).then(function () {
            $scope.obtenerMetecnicas($scope.actualPadreId);
        });
    }

    $scope.cancelarMetecnica = function () {
        $scope.metecnicaBotones = true;
        $scope.metecnicaForm = false;
        $scope.actualId = 0;
        $scope.actual = '';
        $scope.actualPadreId = 0;
    }

    $scope.editarMetecnica = function (id, valor) {
        $scope.metecnicaBotones = false;
        $scope.metecnicaForm = true;
        $scope.actual = valor;
        $scope.actualId = id;
    }
});