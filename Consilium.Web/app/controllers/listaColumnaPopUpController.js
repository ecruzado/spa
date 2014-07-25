app.controller('listaColumnaPopUpController', function ($scope, $modalInstance, listaColumnaDataService, claseCabecera) {
    $scope.user = { userName: "" };
    $scope.lista = [];
    init();

    function init() {
        listaColumnaDataService.listaColumnas(claseCabecera.columnaId, claseCabecera.colegioId, claseCabecera.areaId,
            claseCabecera.nivelId, claseCabecera.gradoId)
            .then(function (resultado) {
                var arr = resultado.data;
                var listaTree = [],
                    nodo1Intex = -1,
                    nodo2Intex = -1,
                    nodo3Intex = -1,
                    nodo1IdAnt = 0,
                    nodo2IdAnt = 0;
                for (i = 0; i < arr.length; i++) {
                    if (arr[i].nodo1Id != nodo1IdAnt) {
                        nodo1Intex++;
                        listaTree[nodo1Intex] = {};
                        listaTree[nodo1Intex].id = 'A-' + arr[i].nodo1Id;
                        listaTree[nodo1Intex].text = arr[i].nodo1Valor;
                        listaTree[nodo1Intex].state = { opened: false };
                        listaTree[nodo1Intex].children = [];
                        nodo1IdAnt = arr[i].nodo1Id;
                        nodo2Intex = -1;
                    }
                    if (arr[i].nodo2Ant != nodo2IdAnt) {
                        nodo2Intex++;
                        listaTree[nodo1Intex].children[nodo2Intex] = {};
                        listaTree[nodo1Intex].children[nodo2Intex]
                            .id = 'E-' + arr[i].nodo2Id;
                        listaTree[nodo1Intex].children[nodo2Intex]
                            .text = arr[i].nodo2Valor;
                        listaTree[nodo1Intex].children[nodo2Intex]
                            .state = { opened: false };
                        listaTree[nodo1Intex].children[nodo2Intex]
                            .children = [];
                        nodo2IdAnt = arr[i].nodo2Id;
                        nodo3Intex = -1;
                    }
                    nodo3Intex++;
                    listaTree[nodo1Intex].children[nodo2Intex]
                        .children[nodo3Intex] = {};
                    listaTree[nodo1Intex].children[nodo2Intex]
                        .children[nodo3Intex].id = 'O-' + arr[i].nodo3Id;
                    listaTree[nodo1Intex].children[nodo2Intex]
                        .children[nodo3Intex].text = arr[i].nodo3Valor;
                }
                $('#jsTreeListaColumna').jstree({
                    'plugins': ["wholerow", "checkbox"],
                    'core': { 'data': listaTree }
                });
            });

    };

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        var seleccion = $("#jsTreeCapacidades").jstree('get_selected');
        $modalInstance.close(seleccion);
    };
});