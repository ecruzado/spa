app.controller('capacidadPopUpController', function ($scope, $modalInstance, capacidadDataService, claseCabecera) {
    $scope.user = { userName: "" };
    $scope.capacidades = [];
    init();
    function init() {
        capacidadDataService.capacidades(claseCabecera.colegioId, claseCabecera.areaId).then(function (results) {
            $scope.capacidades = results.data;
            var arr = results.data;
            var capacidadTree = [],
                nodo1Index = -1,
                nodo2Index = -1,
                nodo3Index = -1,
                nodo1IdAnt = 0,
                nodo2IdAnt = 0;
            for (i = 0; i < arr.length; i++) {
                if (arr[i].nodo1Id != nodo1IdAnt) {
                    nodo1Index++;
                    capacidadTree[nodo1Index] = {};
                    capacidadTree[nodo1Index].id = 'N1-' + arr[i].nodo1Id;
                    capacidadTree[nodo1Index].text = arr[i].nodo1Valor;
                    capacidadTree[nodo1Index].state = { opened: false };
                    capacidadTree[nodo1Index].children = [];
                    nodo1IdAnt = arr[i].nodo1Id;
                    nodo2Index = -1;
                }
                if (arr[i].nodo2Id != nodo2IdAnt) {
                    nodo2Index++;
                    capacidadTree[nodo1Index].children[nodo2Index] = {};
                    capacidadTree[nodo1Index].children[nodo2Index]
                        .id = 'N2-' + arr[i].nodo2Id;
                    capacidadTree[nodo1Index].children[nodo2Index]
                        .text = arr[i].nodo2Valor;
                    capacidadTree[nodo1Index].children[nodo2Index]
                        .state = { opened: false };
                    capacidadTree[nodo1Index].children[nodo2Index]
                        .children = [];
                    nodo2IdAnt = arr[i].nodo2Id;
                    nodo3Index = -1;
                }
                nodo3Index++;
                capacidadTree[nodo1Index].children[nodo2Index]
                    .children[nodo3Index] = {};
                capacidadTree[nodo1Index].children[nodo2Index]
                    .children[nodo3Index].id = 'N3-' + arr[i].nodo3Id;
                capacidadTree[nodo1Index].children[nodo2Index]
                    .children[nodo3Index].text = arr[i].nodo3Valor;
            }
            $('#jsTreeCapacidades').jstree({
                'plugins': ["wholerow", "checkbox"],
                'core': { 'data': capacidadTree }
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