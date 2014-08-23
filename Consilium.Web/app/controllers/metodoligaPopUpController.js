app.controller('metodologiaPopUpController', function ($scope, $modalInstance, metodologiaDataService, claseCabecera) {
    $scope.user = { userName: "" };
    $scope.lista = [];
    init();

    function init() {
        metodologiaDataService.metodologias(claseCabecera.colegioId)
            .then(function (resultado) {
                var arr = resultado.data;
                var listaTree = [],
                    nodo1Intex = -1,
                    nodo2Intex = -1,
                    nodo1IdAnt = 0;
                for (i = 0; i < arr.length; i++) {
                    if (arr[i].nodo1Id != nodo1IdAnt) {
                        nodo1Intex++;
                        listaTree[nodo1Intex] = {};
                        listaTree[nodo1Intex].id = 'N1-' + arr[i].nodo1Id;
                        listaTree[nodo1Intex].text = arr[i].nodo1Valor;
                        listaTree[nodo1Intex].state = { opened: false };
                        listaTree[nodo1Intex].children = [];
                        nodo1IdAnt = arr[i].nodo1Id;
                        nodo2Intex = -1;
                    }
                    nodo2Intex++;
                    listaTree[nodo1Intex].children[nodo2Intex] = {};
                    listaTree[nodo1Intex].children[nodo2Intex]
                        .id = 'N2-' + arr[i].nodo2Id;
                    listaTree[nodo1Intex].children[nodo2Intex]
                        .text = arr[i].nodo2Valor;
                }
                $('#jsTreeListaMetodologias').jstree({
                    'plugins': ["wholerow", "checkbox"],
                    'core': { 'data': listaTree }
                });
            });

    };

    $scope.close = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.guardarSeleccion = function () {
        var seleccion = $("#jsTreeListaMetodologias").jstree('get_selected');
        $modalInstance.close(seleccion);
    };
});