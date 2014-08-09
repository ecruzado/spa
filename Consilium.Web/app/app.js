var baseUrl = $("base").first().attr("href");
console.log("base url for relative links = " + baseUrl);

var app = angular.module('ClaseApp', ['ngRoute', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar', 'textAngular', 'angularFileUpload']);

app.config(function ($routeProvider) {

    $routeProvider.when("/columna/:nombre/:columnaId", {
        controller: "columnaController",
        templateUrl: baseUrl+"app/views/columnaView.html?v=01"
    });

    $routeProvider.when("/crearClase/:nombreArea/:area", {
        controller: "crearClaseController",
        templateUrl: baseUrl + "app/views/crearClaseView.html?v=01"
    });

    $routeProvider.when("/clase/:claseId", {
        controller: "claseController",
        templateUrl: baseUrl + "app/views/claseView.html?v=01"
    });

    $routeProvider.when("/historialClase", {
        controller: "historialClaseController",
        templateUrl: baseUrl + "app/views/historialClaseView.html?v=01"
    });

    $routeProvider.otherwise({ redirectTo: "/crearClase" });

});