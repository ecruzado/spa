﻿var baseUrl = $("base").first().attr("href");

var app = angular.module('ClaseApp', ['ngRoute', 'ui.bootstrap', 'toaster', 'chieffancypants.loadingBar', 'textAngular', 'angularFileUpload']);

app.config(function ($routeProvider) {

    $routeProvider.when("/columna/:nombre/:columnaId", {
        controller: "columnaController",
        templateUrl: baseUrl+"app/views/columnaView.html?v=02"
    });

    $routeProvider.when("/crearClase/:nombreArea/:area", {
        controller: "crearClaseController",
        templateUrl: baseUrl + "app/views/crearClaseView.html?v=02"
    });

    $routeProvider.when("/clase/:claseId", {
        controller: "claseController",
        templateUrl: baseUrl + "app/views/claseView.html?v=02"
    });

    $routeProvider.when("/historialClase", {
        controller: "historialClaseController",
        templateUrl: baseUrl + "app/views/historialClaseView.html?v=02"
    });

    $routeProvider.when("/usuario", {
        controller: "usuarioController",
        templateUrl: baseUrl + "app/views/usuarioView.html?v=02"
    });
    $routeProvider.when("/colegio", {
        controller: "colegioController",
        templateUrl: baseUrl + "app/views/colegioView.html?v=03"
    });
    $routeProvider.when("/metodologia", {
        controller: "metodologiaController",
        templateUrl: baseUrl + "app/views/metodologiaView.html?v=02"
    });
    $routeProvider.when("/valor", {
        controller: "valorController",
        templateUrl: baseUrl + "app/views/valorView.html?v=02"
    });
    $routeProvider.otherwise({ redirectTo: "/crearClase" });

});