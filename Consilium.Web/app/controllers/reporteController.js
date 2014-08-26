app.controller('reporteController', function ($scope, $log, usuarioSesion,
    claseDataService,reporteDataService) {
    $scope.colegioId = usuarioSesion.getUsuario().colegioId;
    $scope.reporteCapacidad = false;
    $scope.reporteContenido = false;
    $scope.reporteMetodos = false;
    $scope.reporteValores = false;
    $scope.reporteIndicadores = false;
    $scope.reporteTipoConocimiento = false;
    $scope.reportePruebas = false;
    $scope.areas = [];
    $scope.niveles = [];
    $scope.grados = [{ gradoId: 0, gradoDesc: '--Seleccionar Grado--' }];
    $scope.rubros = [{ rubro: 'CAPACIDAD' }, { rubro: 'CONTENIDO' }, { rubro: 'METODOLOGIAS' },
        { rubro: 'VALORES' }, { rubro: 'INDICADORES' }, { rubro: 'TIPO DE CONOCIMIENTO' },
        { rubro: 'PRUEBA' }];
    $scope.capacidades = [];
    $scope.contenidos = [];
    $scope.metodos = [];
    $scope.valores = [];
    $scope.inicadores = [];
    $scope.tipoConocimientos = [];
    $scope.pruebas = [];
    init();
    function init() {
        obtenerAreas();
        obtenerNiveles();
    }
    function obtenerAreas() {
        claseDataService.areas().then(function (resultado) {
            $scope.areas = resultado.data;
        });

    }
    function obtenerNiveles() {
        claseDataService.niveles().then(function (resultado) {
            $scope.niveles = resultado.data;
        });
    }
    $scope.obtenerGrados = function () {
        claseDataService.grados($scope.nivelId).then(function (resultado) {
            $scope.gradoId = 0;
            $scope.grados = resultado.data;
        });
    }

    $scope.consultar = function () {
        $scope.reporteCapacidad = false;
        $scope.reporteContenido = false;
        $scope.reporteMetodos = false;
        $scope.reporteValores = false;
        $scope.reporteIndicadores = false;
        $scope.reporteTipoConocimiento = false;
        $scope.reportePruebas = false;


        reporteDataService.obtener($scope.rubro, $scope.colegioId,$scope.area, $scope.nivelId, $scope.gradoId).then(function (resultado) {
            
            if ($scope.rubro == 'CAPACIDAD'){
                $scope.reporteCapacidad = true;
                $scope.capacidades = resultado.data;
            }
            else if ($scope.rubro == 'CONTENIDO'){
                $scope.reporteContenido = true;
                $scope.contenidos = resultado.data;
            }
            else if ($scope.rubro == 'METODOLOGIAS'){
                $scope.reporteMetodos = true;
                $scope.metodos = resultado.data;
            }
            else if ($scope.rubro == 'VALORES'){
                $scope.reporteValores = true;
                $scope.valores = resultado.data;
            }
            else if ($scope.rubro == 'INDICADORES'){
                $scope.reporteIndicadores = true;
                $scope.inicadores = resultado.data;
            }
            else if ($scope.rubro == 'TIPO DE CONOCIMIENTO'){
                $scope.reporteTipoConocimiento = true;
                $scope.tipoConocimientos = resultado.data;
            }
            else if ($scope.rubro == 'PRUEBA'){
                $scope.reportePruebas = true;
                $scope.pruebas = resultado.data;
            }
        });
    };

});