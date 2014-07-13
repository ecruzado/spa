app.controller('claseController', function ($scope, $modal, $log, $routeParams, claseDataService) {
    $scope.claseCabecera = {
        claseId: $routeParams.claseId,
        colegioId: 5,
        areaId: 1,
        nivelId: 1,
        gradoId: 2
    };
    $scope.matriz = {};
    $scope.claseCapacidades = [];
    $scope.niveles = [];
    $scope.grados = [];
    init();
    
    function init() {
        obtenerNiveles();
        obtenerClase();
    }

    function obtenerClase() {
        obtenerClaseCabecera();
        obtenerClaseCapacidades();
        obtenerClaseContenidos();
        obtenerClaseValores();
        obtenerClaseMetodos();
        obtenerClaseActividad();
        obtenerClaseMatriz();
    }

    function obtenerClaseCabecera() {
        claseDataService.clase($scope.claseCabecera.claseId).then(function (resultado) {
            $scope.claseCabecera.titulo = resultado.data.titulo;
            $scope.claseCabecera.fechaInicioFormato = resultado.data.fechaInicioFormato;
            $scope.claseCabecera.fechaFinFormato = resultado.data.fechaFinFormato;
            $scope.selectedNivel = resultado.data.nivelId;
            claseDataService.grados($scope.selectedNivel).then(function (resultadoGrados) {
                $scope.grados = resultadoGrados.data;
                $scope.selectedGrado = resultado.data.gradoId;
            });
        });
    }

    function obtenerClaseCapacidades() {
        claseDataService.claseCapacidades($scope.claseCabecera.claseId).then(function (resultado) {
            var arr = resultado.data;
            var capacidadesTree = [],
                deAreaIndex = -1,
                especificaIndex = -1,
                operativaIndex = -1,
                deAreaIdAnt = 0,
                especificaIdAnt = 0;
            $log.debug(arr);    
            for (i = 0; i < arr.length; i++) {
                if (arr[i].deAreaId != deAreaIdAnt) {
                    deAreaIndex++;
                    capacidadesTree[deAreaIndex] = {};
                    capacidadesTree[deAreaIndex].id = 'A-' + arr[i].deAreaId;
                    capacidadesTree[deAreaIndex].text = arr[i].deArea;
                    capacidadesTree[deAreaIndex].state = { opened: true };
                    capacidadesTree[deAreaIndex].children = [];
                    deAreaIdAnt = arr[i].deAreaId;
                    especificaIndex = -1;
                }
                if (arr[i].especificaId != especificaIdAnt) {
                    especificaIndex++;
                    capacidadesTree[deAreaIndex].children[especificaIndex] = {};
                    capacidadesTree[deAreaIndex].children[especificaIndex]
                        .id = 'E-' + arr[i].especificaId;
                    capacidadesTree[deAreaIndex].children[especificaIndex]
                        .text = arr[i].especifica;
                    capacidadesTree[deAreaIndex].children[especificaIndex]
                        .state = { opened: true };
                    capacidadesTree[deAreaIndex].children[especificaIndex]
                        .children = [];
                    especificaIdAnt = arr[i].especificaId;
                    operativaIndex = -1;
                }
                operativaIndex++;
                capacidadesTree[deAreaIndex].children[especificaIndex]
                    .children[operativaIndex] = {};
                capacidadesTree[deAreaIndex].children[especificaIndex]
                    .children[operativaIndex].id = 'O-' + arr[i].claseCapacidadId;
                capacidadesTree[deAreaIndex].children[especificaIndex]
                    .children[operativaIndex].text = arr[i].operativa;
            }
            /*$scope.claseCapacidades = capacidadesTree;*/
            $('#jtClaseCapacidades').jstree('destroy');
            $('#jtClaseCapacidades').jstree({
                'plugins': ["checkbox"],
                'core': { 'data': capacidadesTree, 'themes': { 'icons': false } }
            });

        });
    }

    function obtenerClaseContenidos() {
        claseDataService.claseContenidos($scope.claseCabecera.claseId).then(function (resultado) {
            var arr = resultado.data;
            var contenidoTree = [],
                conocimientoIndex = -1,
                detalleIndex = -1,
                contenidoIndex = -1,
                conocimientoIdAnt = 0,
                detalleIdAnt = 0;
            $log.debug(arr);
            for (i = 0; i < arr.length; i++) {
                if (arr[i].conocimientoId != conocimientoIdAnt) {
                    conocimientoIndex++;
                    contenidoTree[conocimientoIndex] = {};
                    contenidoTree[conocimientoIndex].id = 'A-' + arr[i].conocimientoId;
                    contenidoTree[conocimientoIndex].text = arr[i].conocimiento;
                    contenidoTree[conocimientoIndex].state = { opened: true };
                    contenidoTree[conocimientoIndex].children = [];
                    conocimientoIdAnt = arr[i].conocimientoId;
                    detalleIndex = -1;
                }
                if (arr[i].detalleId != detalleIdAnt) {
                    detalleIndex++;
                    contenidoTree[conocimientoIndex].children[detalleIndex] = {};
                    contenidoTree[conocimientoIndex].children[detalleIndex]
                        .id = 'B-' + arr[i].detalleId;
                    contenidoTree[conocimientoIndex].children[detalleIndex]
                        .text = arr[i].detalle;
                    contenidoTree[conocimientoIndex].children[detalleIndex]
                        .state = { opened: true };
                    contenidoTree[conocimientoIndex].children[detalleIndex]
                        .children = [];
                    detalleIdAnt = arr[i].detalleId;
                    contenidoIndex = -1;
                }
                contenidoIndex++;
                contenidoTree[conocimientoIndex].children[detalleIndex]
                    .children[contenidoIndex] = {};
                contenidoTree[conocimientoIndex].children[detalleIndex]
                    .children[contenidoIndex].id = 'C-' + arr[i].claseContenidoId;
                contenidoTree[conocimientoIndex].children[detalleIndex]
                    .children[contenidoIndex].text = arr[i].contenidoDesc;
            }

            /*$scope.claseCapacidades = capacidadesTree;*/
            $('#jtClaseContenidos').jstree('destroy');
            $('#jtClaseContenidos').jstree({
                'plugins': ["checkbox"],
                'core': { 'data': contenidoTree, 'themes': { 'icons': false } }
            });

        });
    }

    function obtenerClaseValores() {
        claseDataService.claseValores($scope.claseCabecera.claseId).then(function (resultado) {
            var arr = resultado.data;
            var valoresTree = [],
                valorIndex = -1,
                actitudIndex = -1,
                valorIdAnt = 0;
            $log.debug(arr);
            for (i = 0; i < arr.length; i++) {
                if (arr[i].valorId != valorIdAnt) {
                    valorIndex++;
                    valoresTree[valorIndex] = {};
                    valoresTree[valorIndex].id = 'A-' + arr[i].valorId;
                    valoresTree[valorIndex].text = arr[i].valor;
                    valoresTree[valorIndex].state = { opened: true };
                    valoresTree[valorIndex].children = [];
                    valorIdAnt = arr[i].valorId;
                    actitudIndex = -1;
                }

                actitudIndex++;
                valoresTree[valorIndex]
                    .children[actitudIndex] = {};
                valoresTree[valorIndex]
                    .children[actitudIndex].id = 'B-' + arr[i].claseValorId;
                valoresTree[valorIndex]
                    .children[actitudIndex].text = arr[i].actitud;
            }

            $('#jtClaseValores').jstree('destroy');
            $('#jtClaseValores').jstree({
                'plugins': ["checkbox"],
                'core': { 'data': valoresTree, 'themes': { 'icons': false } }
            });

        });
    }

    function obtenerClaseMetodos() {
        claseDataService.claseMetodos($scope.claseCabecera.claseId).then(function (resultado) {
            var arr = resultado.data;
            var metodosTree = [],
                criterioIndex = -1,
                metecnicaIndex = -1,
                criterioIdAnt = 0;
            for (i = 0; i < arr.length; i++) {
                if (arr[i].criterioId != criterioIdAnt) {
                    criterioIndex++;
                    metodosTree[criterioIndex] = {};
                    metodosTree[criterioIndex].id = 'A-' + arr[i].criterioId;
                    metodosTree[criterioIndex].text = arr[i].criterio;
                    metodosTree[criterioIndex].state = { opened: true };
                    metodosTree[criterioIndex].children = [];
                    criterioIdAnt = arr[i].criterioId;
                    metecnicaIndex = -1;
                }

                metecnicaIndex++;
                metodosTree[criterioIndex]
                    .children[metecnicaIndex] = {};
                metodosTree[criterioIndex]
                    .children[metecnicaIndex].id = 'B-' + arr[i].claseMetodoId;
                metodosTree[criterioIndex]
                    .children[metecnicaIndex].text = arr[i].metecnica;
            }

            $('#jtClaseMetodos').jstree('destroy');
            $('#jtClaseMetodos').jstree({
                'plugins': ["checkbox"],
                'core': { 'data': metodosTree, 'themes': { 'icons': false } }
            });

        });
    }

    function obtenerClaseActividad() {
        claseDataService.claseActividades($scope.claseCabecera.claseId).then(function (resultado) {
            $scope.htmlVariable = resultado.data.actividades;
        });
    }
    
    function obtenerClaseMatriz() {
        claseDataService.claseMatriz($scope.claseCabecera.claseId).then(function (resultado) {
            $scope.matriz = resultado.data;
        });
    }


    function obtenerNiveles() {
        claseDataService.niveles().then(function (resultado) {
            $scope.niveles = resultado.data;
        });
    }

    $scope.openFechaInicio = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.openedFechaInicio = true;
    };
    $scope.openFechaFin = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.openedFechaFin = true;
    };

    $scope.obtenerGrados = function () {
        claseDataService.grados($scope.selectedNivel).then(function (resultado) {
            $scope.grados = resultado.data;
        });
    }

    $scope.popUpCapacidades = function () {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/capacidadPopUpView.html?v=4',
            controller: 'capacidadPopUpController',
            size: 'sm',
            resolve: {
                claseCabecera: function () {
                    return $scope.claseCabecera;
                }
            }
        });
        modalInstance.result.then(function (seleccion) {
            for (i = 0; i < seleccion.length; i++) {
                var auxSeparacion = seleccion[i].split('-');
                if (auxSeparacion[0] == 'O') {
                    var claseCapacidad = {};
                    claseCapacidad.operativaId = auxSeparacion[1];
                    claseCapacidad.claseId = $scope.claseCabecera.claseId;
                    claseDataService.saveClaseCapacidad(claseCapacidad).then(function () {
                        init();
                    });
                }
            }
            $log.debug(seleccion);
        });
    };
    $scope.eliminarCapacidades = function () {
        var arr = $("#jtClaseCapacidades").jstree('get_selected');
        for (i = 0; i < arr.length; i++) {
            var auxSeparacion = arr[i].split('-');
            if (auxSeparacion[0] == 'O') {
                claseDataService.deleteClaseCapacidad(auxSeparacion[1]).then(function () {
                    obtenerClaseCapacidades();
                });
            }
        }
    };
    $scope.popUpContenidos = function () {
        var modalInstance = $modal.open({
            templateUrl: '/app/views/contenidoPopUpView.html?v=4',
            controller: 'contenidoPopUpController',
            size: 'sm',
            resolve: {
                claseCabecera: function () {
                    /*return $scope.claseCabecera;*/
                    return {
                        colegioId: $scope.claseCabecera.colegioId,
                        areaId: $scope.claseCabecera.areaId,
                        nivelId:$scope.selectedNivel,
                        gradoId: $scope.selectedGrado
                    };
                }
            }
        });
        modalInstance.result.then(function (seleccion) {
            for (i = 0; i < seleccion.length; i++) {
                var auxSeparacion = seleccion[i].split('-');
                if (auxSeparacion[0] == 'O') {
                    var claseCapacidad = {};
                    claseCapacidad.operativaId = auxSeparacion[1];
                    claseCapacidad.claseId = $scope.claseCabecera.claseId;
                    claseDataService.saveClaseCapacidad(claseCapacidad).then(function () {
                        init();
                    });
                }
            }
        });
    };
    $scope.eliminarContenidos = function () {
        var arr = $("#jtClaseCapacidades").jstree('get_selected');
        for (i = 0; i < arr.length; i++) {
            var auxSeparacion = arr[i].split('-');
            if (auxSeparacion[0] == 'O') {
                claseDataService.deleteClaseCapacidad(auxSeparacion[1]).then(function () {
                    obtenerClaseCapacidades();
                });
            }
        }
    };
    $scope.ola = function () {
        var claseActividadTemp = {};
        claseActividadTemp.claseId = $scope.claseCabecera.claseId;
        claseActividadTemp.actividades = $scope.htmlVariable
        claseDataService.claseActividadUpdate(claseActividadTemp);
    }
});