app.controller('contenidoPopUpController', function ($scope, $modalInstance,$log, contenidoDataService, claseCabecera) {
    $scope.user = { userName: "" };
    $scope.contenidos = [];
    init();
    function init() {
        contenidoDataService.contenidos(claseCabecera.colegioId, claseCabecera.areaId,
            claseCabecera.nivelId, claseCabecera.gradoId)
            .then(function (resultado) {
                var arr = resultado.data;
                var contenidoTree = [],
                    conocimientoIndex = -1,
                    detalleIndex = -1,
                    contenidoIndex = -1,
                    conocimientoIdAnt = 0,
                    detalleIdAnt = 0;
                for (i = 0; i < arr.length; i++) {
                    if (arr[i].conocimientoId != conocimientoIdAnt) {
                        conocimientoIndex++;
                        contenidoTree[conocimientoIndex] = {};
                        contenidoTree[conocimientoIndex].id = 'A-' + arr[i].conocimientoId;
                        contenidoTree[conocimientoIndex].text = arr[i].conocimiento;
                        contenidoTree[conocimientoIndex].state = { opened: false };
                        contenidoTree[conocimientoIndex].children = [];
                        conocimientoIdAnt = arr[i].conocimientoId;
                        detalleIndex = -1;
                    }
                    if (arr[i].detalleId != detalleIdAnt) {
                        detalleIndex++;
                        contenidoTree[conocimientoIndex].children[detalleIndex] = {};
                        contenidoTree[conocimientoIndex].children[detalleIndex]
                            .id = 'E-' + arr[i].detalleId;
                        contenidoTree[conocimientoIndex].children[detalleIndex]
                            .text = arr[i].detalle;
                        contenidoTree[conocimientoIndex].children[detalleIndex]
                            .state = { opened: false };
                        contenidoTree[conocimientoIndex].children[detalleIndex]
                            .children = [];
                        detalleIdAnt = arr[i].detalleId;
                        contenidoIndex = -1;
                    }
                    contenidoIndex++;
                    contenidoTree[conocimientoIndex].children[detalleIndex]
                        .children[contenidoIndex] = {};
                    contenidoTree[conocimientoIndex].children[detalleIndex]
                        .children[contenidoIndex].id = 'O-' + arr[i].contenidoId;
                    contenidoTree[conocimientoIndex].children[detalleIndex]
                        .children[contenidoIndex].text = arr[i].contenidoDesc;
                }
            $('#jtContenido').jstree({
                'plugins': ["wholerow", "checkbox"],
                'core': { 'data': contenidoTree }
            });
        });

    };

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        var seleccion = $("#jtContenido").jstree('get_selected');
        $modalInstance.close(seleccion);
    };
});