var app = angular.module('ClaseApp', ['ngRoute', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar', 'textAngular', 'angularFileUpload']);

app.config(function ($routeProvider) {

    $routeProvider.when("/columna/:nombre/:columnaId", {
        controller: "columnaController",
        templateUrl: "/app/views/columnaView.html?v=01"
    });

    $routeProvider.when("/crearClase/:nombreArea/:area", {
        controller: "crearClaseController",
        templateUrl: "/app/views/crearClaseView.html?v=01"
    });

    $routeProvider.when("/clase/:claseId", {
        controller: "claseController",
        templateUrl: "/app/views/claseView.html?v=01"
    });

    $routeProvider.when("/historialClase", {
        controller: "historialClaseController",
        templateUrl: "/app/views/historialClaseView.html?v=01"
    });

    $routeProvider.otherwise({ redirectTo: "/crearClase" });

});