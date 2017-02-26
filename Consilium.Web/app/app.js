var baseUrl = $("base").first().attr("href");

var app = angular.module('ClaseApp', ['ngRoute', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar', 'textAngular', 'angularFileUpload']);

app.config(function ($routeProvider) {

    $routeProvider.when("/columna/:nombre/:columnaId", {
        controller: "columnaController",
        templateUrl: baseUrl+"app/views/columnaView.html?v=0.30"
    });

    $routeProvider.when("/crearClase/:nombreArea/:area", {
        controller: "crearClaseController",
        templateUrl: baseUrl + "app/views/crearClaseView.html?v=0.30"
    });

    $routeProvider.when("/clase/:claseId", {
        controller: "claseController",
        templateUrl: baseUrl + "app/views/claseView.html?v=0.30"
    });

    $routeProvider.when("/historialClase", {
        controller: "historialClaseController",
        templateUrl: baseUrl + "app/views/historialClaseView.html?v=0.30"
    });

    $routeProvider.when("/usuario", {
        controller: "usuarioController",
        templateUrl: baseUrl + "app/views/usuarioView.html?v=0.30"
    });
    $routeProvider.when("/colegio", {
        controller: "colegioController",
        templateUrl: baseUrl + "app/views/colegioView.html?v=0.30"
    });
    $routeProvider.when("/metodologia", {
        controller: "metodologiaController",
        templateUrl: baseUrl + "app/views/metodologiaView.html?v=0.30"
    });
    $routeProvider.when("/valor", {
        controller: "valorController",
        templateUrl: baseUrl + "app/views/valorView.html?v=0.30"
    });
    $routeProvider.when("/capacidad", {
        controller: "capacidadController",
        templateUrl: baseUrl + "app/views/capacidadView.html?v=0.30"
    });
    $routeProvider.when("/reporte", {
        controller: "reporteController",
        templateUrl: baseUrl + "app/views/reporteView.html?v=0.30"
    });
    $routeProvider.when("/contenido", {
        controller: "contenidoController",
        templateUrl: baseUrl + "app/views/contenidoView.html?v=0.30"
    });
    $routeProvider.when("/comentario", {
        controller: "comentarioController",
        templateUrl: baseUrl + "app/views/comentarioView.html?v=0.30"
    });
    $routeProvider.when("/area", {
        controller: "areaController",
        templateUrl: baseUrl + "app/views/areaView.html?v=0.30"
    });
    $routeProvider.otherwise({ redirectTo: "/comentario" });

});