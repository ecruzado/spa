app.controller('capacidadPopUpController', function ($scope, $modalInstance, capacidadDataService, claseCabecera) {
    $scope.user = { userName: "" };
    $scope.capacidades = [];
    init();
    function init() {
        capacidadDataService.capacidades(claseCabecera.colegioId, claseCabecera.areaId).then(function (results) {
            $scope.capacidades = results.data;
            var test = [];
            for (i = 0; i < results.data.length; i++) {
                test[i] = {};
                test[i].id = 'A-' + results.data[i].deAreaId;
                test[i].text = results.data[i].nombre;
                test[i].state = { opened: false };
                test[i].children = [];
                for (j = 0; j < results.data[i].especificas.length; j++) {
                    test[i].children[j] = {};
                    test[i].children[j].id = 'E-' + results.data[i].especificas[j].especificaId;
                    test[i].children[j].text = results.data[i].especificas[j].nombre;
                    test[i].children[j].state = { opened: true };
                    test[i].children[j].children = [];
                    for (k = 0; k < results.data[i].especificas[j].operativas.length; k++) {
                        test[i].children[j].children[k] = {};
                        test[i].children[j].children[k].id = 'O-' + results.data[i].especificas[j].operativas[k].operativaId;
                        test[i].children[j].children[k].text = results.data[i].especificas[j].operativas[k].nombre;
                    }
                }
            };
            $('#jsTreeCapacidades').jstree({
                'plugins': ["wholerow", "checkbox"],
                'core': { 'data': test }
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